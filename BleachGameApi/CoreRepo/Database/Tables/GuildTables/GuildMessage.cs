using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreRepo.Database.Tables.Guild
{
    public class GuildMessage : BaseTable
    {
        [ForeignKey("GuildMember")]
        public int GuildMemberId { get; set; }
        public GuildMember GuildMember { get; set; }
    }
}
