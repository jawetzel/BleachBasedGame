using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Database.Tables;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.IDataAccess.IAccountAccess
{
    public interface IRoleAccess : IBaseDataAccess<Role>
    {
        Role GetByDescription(string description);
    }
}
