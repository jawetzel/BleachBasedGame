using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.Database.Tables.Guild
{
    public class Guild : BaseTable
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }


        public ICollection<GuildRank> GuildRanks { get; set; }
        public ICollection<GuildMember> GuildMembers { get; set; }
    }
}
