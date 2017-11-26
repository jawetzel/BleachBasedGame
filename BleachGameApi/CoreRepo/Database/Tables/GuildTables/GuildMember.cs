using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoreRepo.Database.Tables.Account;

namespace CoreRepo.Database.Tables.Guild
{
    public class GuildMember : BaseTable
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Guild")]
        public int GuildId { get; set; }
        public Guild Guild { get; set; }

        [ForeignKey("GuildRank")]
        public int GuildRankId { get; set; }
        public GuildRank GuildRank { get; set; }

        public ICollection<GuildMessage> GuildMessages { get; set; }

    }
}
