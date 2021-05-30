using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ordering.infrastructure.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(44)", maxLength: 44, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(44)", maxLength: 44, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(44)", maxLength: 44, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    State = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    CardName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Expiration = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CVV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(44)", maxLength: 44, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(44)", maxLength: 44, nullable: true),
                    UpdateddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
