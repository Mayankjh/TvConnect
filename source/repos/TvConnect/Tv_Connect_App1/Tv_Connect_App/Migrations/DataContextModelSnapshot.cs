﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tv_Connect_App.Helpers;

namespace Tv_Connect_App.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tv_Connect_App.Entities.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Admin_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            AdminId = 1,
                            Admin_Email = "admin@TvConnect.com",
                            PasswordHash = new byte[] { 80, 250, 166, 170, 65, 94, 170, 234, 104, 169, 61, 171, 82, 253, 64, 11, 95, 45, 95, 181, 20, 209, 80, 117, 204, 229, 11, 161, 198, 116, 139, 85, 106, 128, 146, 247, 231, 195, 7, 19, 231, 152, 139, 189, 231, 43, 51, 93, 174, 190, 240, 209, 218, 83, 202, 191, 246, 154, 107, 77, 70, 255, 204, 167 },
                            PasswordSalt = new byte[] { 49, 29, 11, 206, 250, 222, 63, 94, 64, 151, 190, 51, 253, 6, 82, 172, 101, 199, 246, 251, 188, 250, 173, 189, 64, 37, 11, 42, 22, 87, 60, 37, 34, 192, 165, 188, 162, 85, 68, 135, 138, 213, 204, 50, 96, 250, 221, 177, 139, 186, 190, 102, 21, 165, 93, 252, 9, 169, 98, 239, 0, 96, 148, 135, 36, 49, 135, 94, 215, 240, 102, 76, 218, 219, 183, 219, 57, 93, 113, 141, 212, 141, 170, 199, 172, 245, 209, 247, 160, 171, 192, 29, 221, 105, 203, 66, 149, 144, 39, 65, 241, 147, 253, 54, 25, 67, 29, 249, 158, 2, 149, 221, 188, 86, 100, 150, 33, 201, 193, 247, 192, 63, 96, 13, 22, 34, 175, 38 },
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("Tv_Connect_App.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PlanId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tv_Connect_App.Models.Channel", b =>
                {
                    b.Property<int>("ChannelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ChannelPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Channel_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlanId")
                        .HasColumnType("int");

                    b.HasKey("ChannelId");

                    b.HasIndex("PlanId");

                    b.ToTable("channels");
                });

            modelBuilder.Entity("Tv_Connect_App.Models.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pack_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pack_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("PlanId");

                    b.HasIndex("VendorId");

                    b.ToTable("plans");
                });

            modelBuilder.Entity("Tv_Connect_App.Models.Recharge", b =>
                {
                    b.Property<int>("RechargeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Duration_In_Months")
                        .HasColumnType("int");

                    b.Property<DateTime>("Recharge_Date_Time")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Recharge_Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Recharge_Valid_Thru")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Recharge_time")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RechargeId");

                    b.HasIndex("UserId");

                    b.ToTable("Recharge");
                });

            modelBuilder.Entity("Tv_Connect_App.Models.Vendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vendor_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vendor_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vendor_Pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vendor_contact")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendorId");

                    b.ToTable("vendors");

                    b.HasData(
                        new
                        {
                            VendorId = 1,
                            Email = "vendor1@gmail.com",
                            Image_url = "https://telecomtalk.info/wp-content/uploads/2019/01/trai-d2h-star-india-channels-1200x900.png",
                            Vendor_Address = "32/2 delhi",
                            Vendor_Name = "Tata Sky",
                            Vendor_Pass = "2323",
                            Vendor_contact = "23232323"
                        });
                });

            modelBuilder.Entity("Tv_Connect_App.Entities.User", b =>
                {
                    b.HasOne("Tv_Connect_App.Models.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tv_Connect_App.Models.Channel", b =>
                {
                    b.HasOne("Tv_Connect_App.Models.Plan", "Plan")
                        .WithMany("Channel")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tv_Connect_App.Models.Plan", b =>
                {
                    b.HasOne("Tv_Connect_App.Models.Vendor", "Vendor")
                        .WithMany("Plans")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tv_Connect_App.Models.Recharge", b =>
                {
                    b.HasOne("Tv_Connect_App.Entities.User", "User")
                        .WithMany("Recharge")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}