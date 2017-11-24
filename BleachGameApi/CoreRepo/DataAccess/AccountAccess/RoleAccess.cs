using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Database;
using CoreRepo.Database.Tables.Account;
using CoreRepo.IDataAccess.IAccountAccess;

namespace CoreRepo.DataAccess.AccountAccess
{
    public class RoleAccess : IRoleAccess
    {
        private readonly CoreContext _context;

        public RoleAccess(CoreContext context)
        {
            _context = context;
        }

        public Role Create(Role model)
        {
            try
            {
                _context.Roles.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Role Update(Role model)
        {
            try
            {
                model.LastEditedDate = DateTime.UtcNow;
                _context.Roles.Update(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(Role model)
        {
            try
            {
                _context.Roles.Remove(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Role GetById(int id)
        {
            return  _context.Roles.FirstOrDefault(role => role.Id == id);
        }

        public List<Role> GetAll()
        {
            return _context.Roles.Where(role => role != null).ToList();
        }

        public Role GetByDescription(string description)
        {
            return _context.Roles.FirstOrDefault(role => role.Description.Equals(description));
        }
    }
}
