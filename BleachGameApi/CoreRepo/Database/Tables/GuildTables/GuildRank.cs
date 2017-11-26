using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.Database.Tables.Guild
{
    public class GuildRank : BaseTable
    {
        [ForeignKey("Guild")]
        public int GuildId { get; set; }
        public Guild Guild { get; set; }

        public ICollection<GuildMember> GuildMembers { get; set; }
    }
}
