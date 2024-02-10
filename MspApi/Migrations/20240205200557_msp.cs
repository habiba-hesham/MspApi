using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MspApi.Migrations
{
    public partial class msp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommitteeName",
                table: "Admins",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeadTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Videos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moblie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    URLPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAdmins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SessionPDF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuperAdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Committees_SuperAdmins_SuperAdminID",
                        column: x => x.SuperAdminID,
                        principalTable: "SuperAdmins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moblie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    QR = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    URLPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crew_Committees_CommName",
                        column: x => x.CommName,
                        principalTable: "Committees",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_CommitteeName",
                table: "Admins",
                column: "CommitteeName");

            migrationBuilder.CreateIndex(
                name: "IX_Committees_SuperAdminID",
                table: "Committees",
                column: "SuperAdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_CommName",
                table: "Crew",
                column: "CommName");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Committees_CommitteeName",
                table: "Admins",
                column: "CommitteeName",
                principalTable: "Committees",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Committees_CommitteeName",
                table: "Admins");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Committees");

            migrationBuilder.DropTable(
                name: "SuperAdmins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_CommitteeName",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "CommitteeName",
                table: "Admins");
        }
    }
}
