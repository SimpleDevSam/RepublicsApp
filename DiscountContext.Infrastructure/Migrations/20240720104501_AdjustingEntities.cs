using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscountContext.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Republics_Companies_CompanyId",
                table: "Republics");

            migrationBuilder.DropForeignKey(
                name: "FK_Republics_Companies_CompanyId1",
                table: "Republics");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Republics_RepublicId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Republics_RepublicId1",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_User_UserId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Students_RepublicId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Republics_CompanyId",
                table: "Republics");

            migrationBuilder.DropIndex(
                name: "IX_Republics_CompanyId1",
                table: "Republics");

            migrationBuilder.DropColumn(
                name: "RepublicId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Republics");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Republics");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsOnDiscount",
                table: "Republics",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "OffersDiscount",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Republics_RepublicId",
                table: "Students",
                column: "RepublicId",
                principalTable: "Republics",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Republics_RepublicId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsOnDiscount",
                table: "Republics");

            migrationBuilder.DropColumn(
                name: "OffersDiscount",
                table: "Companies");

            migrationBuilder.AddColumn<Guid>(
                name: "RepublicId1",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Republics",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId1",
                table: "Republics",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_RepublicId1",
                table: "Students",
                column: "RepublicId1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Republics_CompanyId",
                table: "Republics",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Republics_CompanyId1",
                table: "Republics",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Republics_Companies_CompanyId",
                table: "Republics",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Republics_Companies_CompanyId1",
                table: "Republics",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Republics_RepublicId",
                table: "Students",
                column: "RepublicId",
                principalTable: "Republics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Republics_RepublicId1",
                table: "Students",
                column: "RepublicId1",
                principalTable: "Republics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_User_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
