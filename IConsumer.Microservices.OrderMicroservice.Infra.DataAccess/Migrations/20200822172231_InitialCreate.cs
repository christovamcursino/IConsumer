using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Order");

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    TableId = table.Column<Guid>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderStatusId = table.Column<int>(nullable: true),
                    PaymentApproved = table.Column<bool>(nullable: false),
                    PaymentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalSchema: "Order",
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTracking",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TrackingDate = table.Column<DateTime>(nullable: false),
                    OrderStatusId = table.Column<int>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTracking_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderTracking_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalSchema: "Order",
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusId",
                schema: "Order",
                table: "Order",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "Order",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTracking_OrderId",
                schema: "Order",
                table: "OrderTracking",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTracking_OrderStatusId",
                schema: "Order",
                table: "OrderTracking",
                column: "OrderStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "OrderTracking",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "OrderStatus",
                schema: "Order");
        }
    }
}
