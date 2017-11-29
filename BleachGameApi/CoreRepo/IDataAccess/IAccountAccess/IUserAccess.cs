using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.IDataAccess.IAccountAccess
{
    public interface IUserAccess : IBaseDataAccess<User>
    {
        User GetByVerifyString(string verifyString);
        User GetByEmail(string email);
        User GetByConnectionId(string connectionId);
    }
;}
