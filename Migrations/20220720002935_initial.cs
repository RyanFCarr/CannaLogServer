using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Additives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tags = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additives", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Strain = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Breeder = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BaseNutrientsBrand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsFeminized = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TargetPH = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    TransplantDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    HarvestDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GrowType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LightingType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LightingSchedule = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GrowMedium = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TerminationReason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GrowLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AirTemperature = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: true),
                    FinalPH = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    FinalPPM = table.Column<int>(type: "int", nullable: false),
                    GrowMediumTemperature = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: true),
                    Humidity = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: true),
                    InitialPH = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    InitialPPM = table.Column<int>(type: "int", nullable: false),
                    LightHeight = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    PlantAge = table.Column<int>(type: "int", nullable: false),
                    PlantHeight = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: true),
                    Tags = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrowLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrowLogs_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdditiveAdjustments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinalPPM = table.Column<int>(type: "int", nullable: false),
                    InitialPPM = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GrowLogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditiveAdjustments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditiveAdjustments_GrowLogs_GrowLogId",
                        column: x => x.GrowLogId,
                        principalTable: "GrowLogs",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdditiveDosages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdditiveId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: false),
                    UnitofMeasure = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditiveAdjustmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditiveDosages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditiveDosages_AdditiveAdjustments_AdditiveAdjustmentId",
                        column: x => x.AdditiveAdjustmentId,
                        principalTable: "AdditiveAdjustments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdditiveDosages_Additives_AdditiveId",
                        column: x => x.AdditiveId,
                        principalTable: "Additives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Additives",
                columns: new[] { "Id", "Brand", "Name", "Tags", "Type" },
                values: new object[,]
                {
                    { 1, "General Hydroponics", "Micro", null, "NUTES" },
                    { 2, "General Hydroponics", "Bloom", null, "NUTES" },
                    { 3, "General Hydroponics", "CaliMag", null, "NUTES" },
                    { 4, "General Hydroponics", "PH Up", null, "PH" },
                    { 5, "General Hydroponics", "PH Down", null, "PH" },
                    { 6, "Botanicare", "Hydroguard", null, "ROOT SUPPLEMENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveAdjustments_GrowLogId",
                table: "AdditiveAdjustments",
                column: "GrowLogId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveDosages_AdditiveAdjustmentId",
                table: "AdditiveDosages",
                column: "AdditiveAdjustmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveDosages_AdditiveId",
                table: "AdditiveDosages",
                column: "AdditiveId");

            migrationBuilder.CreateIndex(
                name: "IX_GrowLogs_PlantId",
                table: "GrowLogs",
                column: "PlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditiveDosages");

            migrationBuilder.DropTable(
                name: "AdditiveAdjustments");

            migrationBuilder.DropTable(
                name: "Additives");

            migrationBuilder.DropTable(
                name: "GrowLogs");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
