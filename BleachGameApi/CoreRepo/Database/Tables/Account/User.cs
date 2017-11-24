using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreRepo.Database.Tables.Account
{
    public class User : BaseTable
    {
        public User()
        {//begin constructor
            IsVerified = false;
            IsOnline = false;
        }//end constructor

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public bool IsVerified { get; set; }
        public string VerifyString { get; set; }

        public bool IsOnline { get; set; }

        public ICollection<UsersRole> UsersRoles { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
