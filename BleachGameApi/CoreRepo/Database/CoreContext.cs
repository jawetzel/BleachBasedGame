using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CoreRepo.Database
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions options) : base(options) { }
    }
}
