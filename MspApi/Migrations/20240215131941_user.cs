using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MspApi.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Committees_SuperAdmins_SuperAdminId",
                table: "Committees");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Committees_CommitteeName",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "SuperAdmins");

            migrationBuilder.DropTable(
                name: "WaitingUsers");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_CommitteeName",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Committees",
                table: "Committees");

            migrationBuilder.DropIndex(
                name: "IX_Committees_SuperAdminId",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "CommitteeName",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "SuperAdminId",
                table: "Committees");

            migrationBuilder.AddColumn<byte>(
                name: "CommitteeId",
                table: "Sessions",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Committees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<byte>(
                name: "Id",
                table: "Committees",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Committees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Committees",
                table: "Committees",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moblie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    URL_QR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Waiting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitteeId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Committees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "Committees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CommitteeId",
                table: "Sessions",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CommitteeId",
                table: "Users",
                column: "CommitteeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Committees_CommitteeId",
                table: "Sessions",
                column: "CommitteeId",
                principalTable: "Committees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Committees_CommitteeId",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_CommitteeId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Committees",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "CommitteeId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Committees");

            migrationBuilder.AddColumn<string>(
                name: "CommitteeName",
                table: "Sessions",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sessions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Committees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "SuperAdminId",
                table: "Committees",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Committees",
                table: "Committees",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Moblie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    URLPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Moblie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QR = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    URLPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "SuperAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Moblie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    URLPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAdmins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaitingUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Moblie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QR = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    URLPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitingUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaitingUsers_Committees_CommName",
                        column: x => x.CommName,
                        principalTable: "Committees",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CommitteeName",
                table: "Sessions",
                column: "CommitteeName");

            migrationBuilder.CreateIndex(
                name: "IX_Committees_SuperAdminId",
                table: "Committees",
                column: "SuperAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_CommName",
                table: "Crew",
                column: "CommName");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingUsers_CommName",
                table: "WaitingUsers",
                column: "CommName");

            migrationBuilder.AddForeignKey(
                name: "FK_Committees_SuperAdmins_SuperAdminId",
                table: "Committees",
                column: "SuperAdminId",
                principalTable: "SuperAdmins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Committees_CommitteeName",
                table: "Sessions",
                column: "CommitteeName",
                principalTable: "Committees",
                principalColumn: "Name");
        }
    }
}
