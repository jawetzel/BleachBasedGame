using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.IDataAccess.IAccountAccess
{
    public interface IUserAccess
    {
        User Create(User model);
        User Update(User model);
        bool Delete(User model);
        User GetById(int id);
        List<User> GetAll();

        User GetByVerifyString(string verifyString);
        User GetByEmail(string email);

    }
}
