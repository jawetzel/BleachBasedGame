using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreRepo.Database.Tables.Account
{
    public class UsersRole : BaseTable
    {
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
