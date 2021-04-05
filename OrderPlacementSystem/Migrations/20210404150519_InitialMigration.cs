using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderPlacementSystem.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    addressFrom = table.Column<string>(nullable: true),
                    addressTo = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    creationDate = table.Column<DateTime>(nullable: false),
                    updatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order_Service",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(nullable: false),
                    serviceId = table.Column<int>(nullable: false),
                    executeServiceDate = table.Column<DateTime>(nullable: false),
                    creationDate = table.Column<DateTime>(nullable: false),
                    updatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Service", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_Service_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Service_Services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "Services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Moving" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "id", "name" },
                values: new object[] { 2, "Packing" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "id", "name" },
                values: new object[] { 3, "Cleaning" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Service_orderId",
                table: "Order_Service",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Service_serviceId",
                table: "Order_Service",
                column: "serviceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Service");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
