using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.Database.Tables.Global
{
    public class WorldMessage : BaseTable
    {
        public string Message { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
