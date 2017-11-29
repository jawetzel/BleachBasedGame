using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Database;
using CoreRepo.Database.Tables.Account;
using CoreRepo.IDataAccess.IAccountAccess;

namespace CoreRepo.DataAccess.AccountAccess
{
    public class UserAccess : BaseDataAccess<User>, IUserAccess
    {
        private readonly CoreContext _context;

        public UserAccess(CoreContext context)
        {
            _context = context;
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
