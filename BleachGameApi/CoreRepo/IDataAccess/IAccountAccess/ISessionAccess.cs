using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.IDataAccess.IAccountAccess
{
    public interface ISessionAccess : IBaseDataAccess<Session>
    {
        Session GetByToken(string token);
        List<Session> GetListByUserId(int id);
    }
}
