using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IConsumer.Microservices.StoreMicroservice.Infra.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Store");

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CNPJ = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_Suburb = table.Column<string>(nullable: true),
                    Address_Town = table.Column<string>(nullable: true),
                    Address_State = table.Column<string>(nullable: true),
                    Address_Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreTable",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StoreId = table.Column<Guid>(nullable: false),
                    TableNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreTable_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Store",
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreTable_StoreId",
                schema: "Store",
                table: "StoreTable",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreTable",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Store");
        }
    }
}
