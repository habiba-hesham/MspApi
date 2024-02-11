using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MspApi.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Committees_CommitteeName",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Committees_SuperAdmins_SuperAdminID",
                table: "Committees");

            migrationBuilder.DropIndex(
                name: "IX_Admins_CommitteeName",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "SessionPDF",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "CommitteeName",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "SuperAdminID",
                table: "Committees",
                newName: "SuperAdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Committees_SuperAdminID",
                table: "Committees",
                newName: "IX_Committees_SuperAdminId");

            migrationBuilder.AlterColumn<int>(
                name: "SuperAdminId",
                table: "Committees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Committees",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    SessionPDF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitteeName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Committees_CommitteeName",
                        column: x => x.CommitteeName,
                        principalTable: "Committees",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "WaitingUsers",
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
                name: "IX_WaitingUsers_CommName",
                table: "WaitingUsers",
                column: "CommName");

            migrationBuilder.AddForeignKey(
                name: "FK_Committees_SuperAdmins_SuperAdminId",
                table: "Committees",
                column: "SuperAdminId",
                principalTable: "SuperAdmins",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Committees_SuperAdmins_SuperAdminId",
                table: "Committees");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "WaitingUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Committees");

            migrationBuilder.RenameColumn(
                name: "SuperAdminId",
                table: "Committees",
                newName: "SuperAdminID");

            migrationBuilder.RenameIndex(
                name: "IX_Committees_SuperAdminId",
                table: "Committees",
                newName: "IX_Committees_SuperAdminID");

            migrationBuilder.AlterColumn<int>(
                name: "SuperAdminID",
                table: "Committees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionPDF",
                table: "Committees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Committees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CommitteeName",
                table: "Admins",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_CommitteeName",
                table: "Admins",
                column: "CommitteeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Committees_CommitteeName",
                table: "Admins",
                column: "CommitteeName",
                principalTable: "Committees",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Committees_SuperAdmins_SuperAdminID",
                table: "Committees",
                column: "SuperAdminID",
                principalTable: "SuperAdmins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
