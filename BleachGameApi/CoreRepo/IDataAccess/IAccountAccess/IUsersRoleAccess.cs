using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.IDataAccess.IAccountAccess
{
    public interface IUsersRoleAccess
    {
        UsersRole Create(UsersRole model);
        UsersRole Update(UsersRole model);
        bool Delete(UsersRole model);
        UsersRole GetById(int id);
        List<UsersRole> GetAll();

        List<UsersRole> GetListByUserId(int id);
        List<UsersRole> GetListByRoleId(int id);
        UsersRole GetByUserIdAndRoleId(int userId, int roleId);
    }
}
