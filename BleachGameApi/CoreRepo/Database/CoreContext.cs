using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Database.Tables.Account;
using CoreRepo.Database.Tables.Global;
using CoreRepo.Database.Tables.Guild;
using CoreRepo.Database.Tables.PrivateMessage;
using Microsoft.EntityFrameworkCore;

namespace CoreRepo.Database
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsersRole> UsersRoles { get; set; }

        public DbSet<MessageGroup> MessageGroups { get; set; }
        public DbSet<MessageGroupUser> MessageGroupUsers { get; set; }
        public DbSet<GroupMessage> GroupMessages { get; set; }

        public DbSet<WorldMessage> WorldMessages { get; set; }

        public DbSet<Guild> Guilds { get; set; }
        public DbSet<GuildMember> GuildMembers { get; set; }
        public DbSet<GuildRank> GuildRanks { get; set; }
        public DbSet<GuildMessage> GuildMessages { get; set; }

    }
}
