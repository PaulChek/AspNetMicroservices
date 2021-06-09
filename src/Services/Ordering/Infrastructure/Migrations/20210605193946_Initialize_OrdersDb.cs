using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initialize_OrdersDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    AddressLine = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    CardName = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    Expiration = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CVV = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
