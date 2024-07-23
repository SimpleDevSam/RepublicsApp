using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscountContext.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address_Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address_Neighbourhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BusinessType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Republics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address_Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address_Neighbourhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Republics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Republics_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Republics_Companies_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name_LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate_BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RepublicId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Republics_RepublicId",
                        column: x => x.RepublicId,
                        principalTable: "Republics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Republics_RepublicId1",
                        column: x => x.RepublicId1,
                        principalTable: "Republics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    QuantityUsed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discounts_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_CompanyId",
                table: "Discounts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_StudentId",
                table: "Discounts",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Republics_CompanyId",
                table: "Republics",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Republics_CompanyId1",
                table: "Republics",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RepublicId",
                table: "Students",
                column: "RepublicId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RepublicId1",
                table: "Students",
                column: "RepublicId1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Republics");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
