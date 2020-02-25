using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tv_Connect_App.Entities;
using Tv_Connect_App.Models;

namespace Tv_Connect_App.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("Database"));
            Console.WriteLine("DB CONNECTED");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Channel> channels { get; set; }
        public DbSet<Vendor> vendors { get; set; }
        public DbSet<Plan> plans { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}
