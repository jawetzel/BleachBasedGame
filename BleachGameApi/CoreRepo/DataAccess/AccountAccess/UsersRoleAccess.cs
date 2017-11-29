using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Database;
using CoreRepo.Database.Tables.Account;
using CoreRepo.IDataAccess.IAccountAccess;

namespace CoreRepo.DataAccess.AccountAccess
{
    public class UsersRoleAccess : BaseDataAccess<UsersRole>, IUsersRoleAccess
    {
        private readonly CoreContext _context;

        public UsersRoleAccess(CoreContext context)
        {
            _context = context;
        }

        public List<UsersRole> GetListByUserId(int id)
        {
            return _context.UsersRoles.Where(usersRole => usersRole.UserId == id).ToList();
        }

        public List<UsersRole> GetListByRoleId(int id)
        {
            return _context.UsersRoles.Where(usersRole => usersRole.RoleId == id).ToList();
        }

        public UsersRole GetByUserIdAndRoleId(int userId, int roleId)
        {
            return _context.UsersRoles.FirstOrDefault(usersRole => usersRole.RoleId == userId && usersRole.UserId == roleId);
        }
    }
}
