using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreRepo.Database.Tables.Account
{
    public class Session : BaseTable
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
