using System;
using System.Collections.Generic;
using System.Text;
using CoreRepo.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoreRepo
{
    public class ContextFactory : IDesignTimeDbContextFactory<CoreContext>
    {   //Setup db for migrations
        public static string ReturnLocalConnectionString()
        {
            //live Connection
            return "Server=(localdb)\\mssqllocaldb;Database=BleachGameDb;Trusted_Connection=True;MultipleActiveResultSets=true;";
        }

        public CoreContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CoreContext>();
            builder.UseSqlServer(ReturnLocalConnectionString());
            return new CoreContext(builder.Options);
        }
    }
}
