using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyFriendsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFriendsApp.Contexts
{
    public class MyFriendsContext : DbContext
    {
        public IConfiguration _config;

        public DbSet<Friend> Friends { get; set; }

        public MyFriendsContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["database:connection"]);
        }
    }
}
