using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Database;
using CoreRepo.Database.Tables.Account;
using CoreRepo.IDataAccess.IAccountAccess;

namespace CoreRepo.DataAccess.AccountAccess
{
    public class UserAccess : IUserAccess
    {
        private readonly CoreContext _context;

        public UserAccess(CoreContext context)
        {
            _context = context;
        }


        public User Create(User model)
        {
            try
            {
                _context.Users.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User Update(User model)
        {
            try
            {
                model.LastEditedDate = DateTime.UtcNow;
                _context.Users.Update(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(User model)
        {
            try
            {
                _context.Users.Remove(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public List<User> GetAll()
        {
            return _context.Users.Where(user => user != null).ToList();
        }

        public User GetByVerifyString(string verifyString)
        {
            return _context.Users.FirstOrDefault(user => user.VerifyString.Equals(verifyString));
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(user => user.Email.Equals(email));
        }

        public User GetByConnectionId(string connectionId)
        {
            return _context.Users.FirstOrDefault(user => user.ConnectionId.Equals(connectionId));
        }
    }
}
