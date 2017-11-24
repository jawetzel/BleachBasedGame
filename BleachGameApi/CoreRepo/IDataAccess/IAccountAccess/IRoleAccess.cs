using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.IDataAccess.IAccountAccess
{
    public interface IRoleAccess
    {
        Role Create(Role model);
        Role Update(Role model);
        bool Delete(Role model);
        Role GetById(int id);
        List<Role> GetAll();

        Role GetByDescription(string description);
    }
}
