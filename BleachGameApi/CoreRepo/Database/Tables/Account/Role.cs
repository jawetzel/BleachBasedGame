using System;
using System.Collections.Generic;
using System.Text;

namespace CoreRepo.Database.Tables.Account
{
    public class Role : BaseTable
    {
        public string Description { get; set; }

        public ICollection<UsersRole> UsersRoles { get; set; }
    }
}
