using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Database;
using CoreRepo.Database.Tables.Account;
using CoreRepo.IDataAccess.IAccountAccess;

namespace CoreRepo.DataAccess.AccountAccess
{
    public class UsersRoleAccess : IUsersRoleAccess
    {
        private readonly CoreContext _context;

        public UsersRoleAccess(CoreContext context)
        {
            _context = context;
        }

        public UsersRole Create(UsersRole model)
        {
            try
            {
                _context.UsersRoles.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public UsersRole Update(UsersRole model)
        {
            try
            {
                model.LastEditedDate = DateTime.UtcNow;
                _context.UsersRoles.Update(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(UsersRole model)
        {
            try
            {
                _context.UsersRoles.Remove(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UsersRole GetById(int id)
        {
            return _context.UsersRoles.FirstOrDefault(usersRole => usersRole.Id == id);
        }

        public List<UsersRole> GetAll()
        {
            return _context.UsersRoles.Where(usersRole => usersRole != null).ToList();
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
