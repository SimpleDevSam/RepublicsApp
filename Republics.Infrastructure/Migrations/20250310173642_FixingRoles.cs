using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiscountContext.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId1",
                table: "User");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("1c9a4086-d224-4738-8ee2-6bdf8f12ee3a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a4f2c8d7-1d60-4f6f-825b-db6fa4b8b9f8"));

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "User");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleType" },
                values: new object[,]
                {
                    { new Guid("42f824c2-3c24-4994-90bd-668ef96cd80d"), 1 },
                    { new Guid("955e5bde-b8dc-49dd-9dae-b740c62f36ef"), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("42f824c2-3c24-4994-90bd-668ef96cd80d"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("955e5bde-b8dc-49dd-9dae-b740c62f36ef"));

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleType" },
                values: new object[,]
                {
                    { new Guid("1c9a4086-d224-4738-8ee2-6bdf8f12ee3a"), 1 },
                    { new Guid("a4f2c8d7-1d60-4f6f-825b-db6fa4b8b9f8"), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId1",
                table: "User",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId1",
                table: "User",
                column: "RoleId1",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
