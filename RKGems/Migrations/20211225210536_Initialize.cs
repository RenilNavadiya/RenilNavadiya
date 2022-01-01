using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RKGems.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseWeight = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResultThan = table.Column<double>(type: "float", nullable: false),
                    ResultWeight = table.Column<double>(type: "float", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_Results_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FourPs",
                columns: table => new
                {
                    FourPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FourPQuantity = table.Column<double>(type: "float", nullable: false),
                    FourPWeight = table.Column<double>(type: "float", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    IdOfResult = table.Column<int>(type: "int", nullable: false),
                    WeightOfResultResultId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FourPs", x => x.FourPId);
                    table.ForeignKey(
                        name: "FK_FourPs_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FourPs_Results_WeightOfResultResultId",
                        column: x => x.WeightOfResultResultId,
                        principalTable: "Results",
                        principalColumn: "ResultId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Polishes",
                columns: table => new
                {
                    PolishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolishQuantity = table.Column<double>(type: "float", nullable: false),
                    PolishWeight = table.Column<double>(type: "float", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    IdOfResult = table.Column<int>(type: "int", nullable: false),
                    WeightOfResultResultId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polishes", x => x.PolishId);
                    table.ForeignKey(
                        name: "FK_Polishes_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polishes_Results_WeightOfResultResultId",
                        column: x => x.WeightOfResultResultId,
                        principalTable: "Results",
                        principalColumn: "ResultId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Russians",
                columns: table => new
                {
                    RussianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RussianQuantity = table.Column<double>(type: "float", nullable: false),
                    RussianWeight = table.Column<double>(type: "float", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    IdOfFourP = table.Column<int>(type: "int", nullable: false),
                    WeightOfFourPFourPId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Russians", x => x.RussianId);
                    table.ForeignKey(
                        name: "FK_Russians_FourPs_WeightOfFourPFourPId",
                        column: x => x.WeightOfFourPFourPId,
                        principalTable: "FourPs",
                        principalColumn: "FourPId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Russians_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Purchase",
                columns: new[] { "Id", "DueDate", "ItemNumber", "PartyName", "Price", "PurchaseWeight" },
                values: new object[] { 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A1", "Renil", 1000.0, 100.0 });

            migrationBuilder.InsertData(
                table: "Purchase",
                columns: new[] { "Id", "DueDate", "ItemNumber", "PartyName", "Price", "PurchaseWeight" },
                values: new object[] { 2, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A2", "Keyur", 2000.0, 150.0 });

            migrationBuilder.InsertData(
                table: "Purchase",
                columns: new[] { "Id", "DueDate", "ItemNumber", "PartyName", "Price", "PurchaseWeight" },
                values: new object[] { 3, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A3", "Piyush", 3000.0, 200.0 });

            migrationBuilder.InsertData(
                table: "FourPs",
                columns: new[] { "FourPId", "FourPQuantity", "FourPWeight", "IdOfResult", "PurchaseId", "WeightOfResultResultId" },
                values: new object[,]
                {
                    { 1, 50.0, 70.0, 1, 1, null },
                    { 2, 60.0, 60.0, 2, 2, null },
                    { 3, 70.0, 50.0, 3, 3, null }
                });

            migrationBuilder.InsertData(
                table: "Polishes",
                columns: new[] { "PolishId", "IdOfResult", "PolishQuantity", "PolishWeight", "PurchaseId", "WeightOfResultResultId" },
                values: new object[,]
                {
                    { 1, 1, 50.0, 60.0, 1, null },
                    { 2, 2, 60.0, 50.0, 2, null },
                    { 3, 3, 70.0, 40.0, 3, null }
                });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "ResultId", "PurchaseId", "ResultThan", "ResultWeight" },
                values: new object[,]
                {
                    { 1, 1, 50.0, 75.0 },
                    { 2, 2, 60.0, 65.0 },
                    { 3, 3, 70.0, 55.0 }
                });

            migrationBuilder.InsertData(
                table: "Russians",
                columns: new[] { "RussianId", "IdOfFourP", "PurchaseId", "RussianQuantity", "RussianWeight", "WeightOfFourPFourPId" },
                values: new object[,]
                {
                    { 1, 1, 1, 50.0, 65.0, null },
                    { 2, 2, 2, 60.0, 55.0, null },
                    { 3, 3, 3, 70.0, 45.0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FourPs_PurchaseId",
                table: "FourPs",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_FourPs_WeightOfResultResultId",
                table: "FourPs",
                column: "WeightOfResultResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Polishes_PurchaseId",
                table: "Polishes",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Polishes_WeightOfResultResultId",
                table: "Polishes",
                column: "WeightOfResultResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_PurchaseId",
                table: "Results",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Russians_PurchaseId",
                table: "Russians",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Russians_WeightOfFourPFourPId",
                table: "Russians",
                column: "WeightOfFourPFourPId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polishes");

            migrationBuilder.DropTable(
                name: "Russians");

            migrationBuilder.DropTable(
                name: "FourPs");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Purchase");
        }
    }
}
