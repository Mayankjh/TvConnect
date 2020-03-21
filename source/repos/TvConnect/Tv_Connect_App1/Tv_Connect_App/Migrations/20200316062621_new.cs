using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tv_Connect_App.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_Email = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "vendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vendor_Name = table.Column<string>(nullable: true),
                    Image_url = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Vendor_Pass = table.Column<string>(nullable: true),
                    Vendor_Address = table.Column<string>(nullable: true),
                    Vendor_contact = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendors", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "plans",
                columns: table => new
                {
                    PlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pack_Price = table.Column<decimal>(nullable: false),
                    Image_url = table.Column<string>(nullable: true),
                    Pack_Name = table.Column<string>(nullable: true),
                    VendorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plans", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_plans_vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "channels",
                columns: table => new
                {
                    ChannelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Channel_Name = table.Column<string>(nullable: true),
                    ChannelPrice = table.Column<decimal>(nullable: false),
                    PlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_channels", x => x.ChannelId);
                    table.ForeignKey(
                        name: "FK_channels_plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "plans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    User_Email = table.Column<string>(nullable: true),
                    User_Phone = table.Column<string>(nullable: true),
                    PlanId = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "plans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recharge",
                columns: table => new
                {
                    RechargeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Recharge_time = table.Column<DateTime>(nullable: false),
                    Recharge_Status = table.Column<bool>(nullable: false),
                    Recharge_Date_Time = table.Column<DateTime>(nullable: false),
                    Recharge_Valid_Thru = table.Column<DateTime>(nullable: false),
                    Duration_In_Months = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recharge", x => x.RechargeId);
                    table.ForeignKey(
                        name: "FK_Recharge_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminId", "Admin_Email", "PasswordHash", "PasswordSalt", "Role", "Token" },
                values: new object[] { 1, "admin@TvConnect.com", new byte[] { 80, 250, 166, 170, 65, 94, 170, 234, 104, 169, 61, 171, 82, 253, 64, 11, 95, 45, 95, 181, 20, 209, 80, 117, 204, 229, 11, 161, 198, 116, 139, 85, 106, 128, 146, 247, 231, 195, 7, 19, 231, 152, 139, 189, 231, 43, 51, 93, 174, 190, 240, 209, 218, 83, 202, 191, 246, 154, 107, 77, 70, 255, 204, 167 }, new byte[] { 49, 29, 11, 206, 250, 222, 63, 94, 64, 151, 190, 51, 253, 6, 82, 172, 101, 199, 246, 251, 188, 250, 173, 189, 64, 37, 11, 42, 22, 87, 60, 37, 34, 192, 165, 188, 162, 85, 68, 135, 138, 213, 204, 50, 96, 250, 221, 177, 139, 186, 190, 102, 21, 165, 93, 252, 9, 169, 98, 239, 0, 96, 148, 135, 36, 49, 135, 94, 215, 240, 102, 76, 218, 219, 183, 219, 57, 93, 113, 141, 212, 141, 170, 199, 172, 245, 209, 247, 160, 171, 192, 29, 221, 105, 203, 66, 149, 144, 39, 65, 241, 147, 253, 54, 25, 67, 29, 249, 158, 2, 149, 221, 188, 86, 100, 150, 33, 201, 193, 247, 192, 63, 96, 13, 22, 34, 175, 38 }, "Admin", null });

            migrationBuilder.InsertData(
                table: "vendors",
                columns: new[] { "VendorId", "Email", "Image_url", "Role", "Token", "Vendor_Address", "Vendor_Name", "Vendor_Pass", "Vendor_contact" },
                values: new object[] { 1, "vendor1@gmail.com", "https://telecomtalk.info/wp-content/uploads/2019/01/trai-d2h-star-india-channels-1200x900.png", null, null, "32/2 delhi", "Tata Sky", "2323", "23232323" });

            migrationBuilder.CreateIndex(
                name: "IX_channels_PlanId",
                table: "channels",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_plans_VendorId",
                table: "plans",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Recharge_UserId",
                table: "Recharge",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PlanId",
                table: "Users",
                column: "PlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "channels");

            migrationBuilder.DropTable(
                name: "Recharge");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "plans");

            migrationBuilder.DropTable(
                name: "vendors");
        }
    }
}
