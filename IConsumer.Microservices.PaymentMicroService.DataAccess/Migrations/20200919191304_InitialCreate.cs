using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IConsumer.Microservices.PaymentMicroService.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Payment");

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    InvoiceTotal = table.Column<decimal>(nullable: false),
                    InvoiceStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    PaymentValue = table.Column<decimal>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    InvoiceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Payment",
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_InvoiceId",
                schema: "Payment",
                table: "Payment",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment",
                schema: "Payment");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "Payment");
        }
    }
}
