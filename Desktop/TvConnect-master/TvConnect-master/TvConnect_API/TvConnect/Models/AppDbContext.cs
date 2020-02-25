using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvConnect.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TvConnect.Models.User> users { get; set; }
        public DbSet<TvConnect.Models.Channel> channels { get; set; }
        public DbSet<TvConnect.Models.Vendor> vendors { get; set; }
        public DbSet<TvConnect.Models.Plan> plans { get; set; }
    }
}
