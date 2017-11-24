using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.IDataAccess.IAccountAccess
{
    public interface ISessionAccess
    {
        Session Create(Session model);
        Session Update(Session model);
        bool Delete(Session model);
        Session GetById(int id);
        Session GetByToken(string token);
        List<Session> GetAll();

        List<Session> GetListByUserId(int id);
    }
}
