using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Database.Tables.Account;
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
    }
}
