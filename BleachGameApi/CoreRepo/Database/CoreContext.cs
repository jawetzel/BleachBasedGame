﻿using System;
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
    }
}
