using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Database;
using CoreRepo.Database.Tables.Account;
using CoreRepo.IDataAccess.IAccountAccess;

namespace CoreRepo.DataAccess.AccountAccess
{
    public class RoleAccess : BaseDataAccess<Role>, IRoleAccess
    {
        private readonly CoreContext _context;

        public RoleAccess(CoreContext context)
        {
            _context = context;
        }

        public Role GetByDescription(string description)
        {
            return _context.Roles.FirstOrDefault(role => role.Description.Equals(description));
        }
    }
}
