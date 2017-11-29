using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.IDataAccess.IAccountAccess
{
    public interface IUsersRoleAccess : IBaseDataAccess<UsersRole>
    {
        List<UsersRole> GetListByUserId(int id);
        List<UsersRole> GetListByRoleId(int id);
        UsersRole GetByUserIdAndRoleId(int userId, int roleId);
    }
}
