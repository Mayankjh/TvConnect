using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tv_Connect_App.Entities;
using Tv_Connect_App.Models;
using Tv_Connect_App.Services;
namespace Tv_Connect_App.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

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
        public DbSet<Recharge> Recharge { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            base.OnModelCreating(modelBuilder);
            //seed categories
            modelBuilder.Entity<Vendor>().HasData(new Vendor
                        {
                            VendorId = 1,
                            Vendor_Name = "Tata Sky",
                            Image_url = "https://telecomtalk.info/wp-content/uploads/2019/01/trai-d2h-star-india-channels-1200x900.png",
                            Email ="vendor1@gmail.com",
                            Vendor_Pass="2323",
                            Vendor_Address="32/2 delhi",
                            Vendor_contact= "23232323"
                         });
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash("m123", out passwordHash, out passwordSalt);
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                AdminId = 1,
                Admin_Email = "admin@TvConnect.com",
                Role = "Admin",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            }) ;

        }

    }
}
