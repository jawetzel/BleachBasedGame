using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using CoreRepo.Database.Tables.Account;
using CoreRepo.IDataAccess.IAccountAccess;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CoreServices.AccountServices
{
    public class AccountSerurityService
    {
        private readonly ISessionAccess _sessionAccess;
        private readonly IUserAccess _userAccess;
        private readonly IUsersRoleAccess _usersRoleAccess;
        private readonly IRoleAccess _roleAccess;

        public AccountSerurityService(ISessionAccess sessionAccess, IUserAccess userAccess, IUsersRoleAccess usersRoleAccess,
            IRoleAccess roleAccess)
        {
            _sessionAccess = sessionAccess;
            _userAccess = userAccess;
            _usersRoleAccess = usersRoleAccess;
            _roleAccess = roleAccess;
        }


        public Session CheckToken(string token)
        {
            var session = _sessionAccess.GetByToken(token);
            return (session != null && session.ExpireDate >= DateTime.UtcNow) ? session : null;
        }

        public bool CheckIsAdmin(string token)
        {
            var session = _sessionAccess.GetByToken(token);
            if (session == null) return false;

            var role = _roleAccess.GetByDescription("Admin");
            if (role == null) return false;

            var usersRole = _usersRoleAccess.GetByUserIdAndRoleId(session.UserId, role.Id);
            return usersRole != null;
        }
        public bool UpdatePassword(string password, string token)
        {
            var session = _sessionAccess.GetByToken(token);
            var founduser = _userAccess.GetById(session.UserId);
            if (founduser == null) return false;
            founduser.Salt = CreateSalt();
            founduser.Password = password;
            founduser = NewPassword(founduser);
            return _userAccess.Update(founduser) != null;
        }

        public Session Login(User user)
        {
            var foundUser = _userAccess.GetByEmail(user.Email);
            if (foundUser == null) return null;
            user.Salt = foundUser.Salt;
            return foundUser.Password.Equals(EncryptPassword(user)) ?  CreateSession(foundUser) : null;
        }
        public Session CreateSession(User user)
        {
            var session = new Session
            {
                Token = DateTime.UtcNow + " " + Guid.NewGuid(),
                ExpireDate = DateTime.UtcNow.AddHours(8),
                User = user,
                UserId = user.Id
            };
            return _sessionAccess.Create(session) != null ? session : null;
        }
        public User Register(User user)
        {
            if (_userAccess.GetByEmail(user.Email) != null) return null;
            var newUser = new User
            {
                Email = user.Email,
                Password = user.Password,
                VerifyString = (DateTime.UtcNow.Date + Guid.NewGuid().ToString()).Replace("-", string.Empty).Replace(" ", string.Empty)
            };
            var createdUser = NewPassword(newUser);
            var returnUser = _userAccess.Create(createdUser);
            if (returnUser != null)
            {
                //Todo: Fix Email Sent For Verify
                Email.SendEmail(returnUser.Email, "Email Verification - NoReply",
                    "Thank you for registering with us, this email is to verify your email. Please click the following link to verify your account.\n\n "
                    + "http://InsertAddressHere.com" + returnUser.VerifyString);
            }
            return returnUser;
        }

        public User ResendEmailVerify(User user)
        {
            var founduser = _userAccess.GetByEmail(user.Email);
            if (founduser == null) return null;
            //Todo: Fix Email Sent For Verify
            Email.SendEmail(founduser.Email, "Email Verification - NoReply",
                "Thank you for registering with us, this email is to verify your email. Please click the following link to verify your account.\n\n "
                + "http://InsertAddressHere.com" + founduser.VerifyString);
            return founduser;
        }

        public User GetUserByEmail(string email)
        {
            return _userAccess.GetByEmail(email);
        }

        public bool VerifyEmailAddress(string verifyString)
        {
            var foundUser = _userAccess.GetByVerifyString(verifyString);
            if (foundUser == null) return false;
            foundUser.IsVerified = true;
            return _userAccess.Update(foundUser) != null;
        }

        public User NewPassword(User user)
        {
            user.Salt = CreateSalt();
            user.Password = EncryptPassword(user);
            user.LastEditedDate = DateTime.UtcNow;
            return user;
        }

        private byte[] CreateSalt()
        {
            var salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public string EncryptPassword(User user)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.Password,
                salt: user.Salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}
