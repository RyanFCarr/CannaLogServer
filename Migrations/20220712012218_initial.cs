﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Additive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breeder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseNutrientsBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFeminized = table.Column<bool>(type: "bit", nullable: false),
                    TargetPH = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    TransplantDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HarvestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GrowType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LightingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LightingSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrowMedium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true, computedColumnSql: "CASE WHEN TransplantDate IS NULL THEN NULL ELSE DATEDIFF(DAY, TransplantDate, COALESCE(HarvestDate, GETDATE())) END")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrowLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirTemperature = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: true),
                    FinalPH = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    FinalPPM = table.Column<int>(type: "int", nullable: false),
                    GrowMediumTemperature = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: true),
                    Humidity = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: true),
                    InitialPH = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    InitialPPM = table.Column<int>(type: "int", nullable: false),
                    LightHeight = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    PlantAge = table.Column<int>(type: "int", nullable: false),
                    PlantHeight = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AdditiveAdjustment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinalPPM = table.Column<int>(type: "int", nullable: false),
                    InitialPPM = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrowLogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditiveAdjustment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditiveAdjustment_GrowLogs_GrowLogId",
                        column: x => x.GrowLogId,
                        principalTable: "GrowLogs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdditiveDosage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditiveId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: false),
                    UnitofMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditiveAdjustmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditiveDosage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditiveDosage_Additive_AdditiveId",
                        column: x => x.AdditiveId,
                        principalTable: "Additive",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditiveDosage_AdditiveAdjustment_AdditiveAdjustmentId",
                        column: x => x.AdditiveAdjustmentId,
                        principalTable: "AdditiveAdjustment",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Additive",
                columns: new[] { "Id", "Brand", "Name", "Tags", "Type" },
                values: new object[,]
                {
                    { 1, "General Hydroponics", "Micro", null, "NUTES" },
                    { 2, "General Hydroponics", "Bloom", null, "NUTES" },
                    { 3, "General Hydroponics", "CaliMag", null, "NUTES" },
                    { 4, "General Hydroponics", "PH Up", null, "PH" },
                    { 5, "General Hydroponics", "PH Down", null, "PH" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveAdjustment_GrowLogId",
                table: "AdditiveAdjustment",
                column: "GrowLogId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveDosage_AdditiveAdjustmentId",
                table: "AdditiveDosage",
                column: "AdditiveAdjustmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveDosage_AdditiveId",
                table: "AdditiveDosage",
                column: "AdditiveId");

            migrationBuilder.CreateIndex(
                name: "IX_GrowLogs_PlantId",
                table: "GrowLogs",
                column: "PlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditiveDosage");

            migrationBuilder.DropTable(
                name: "Additive");

            migrationBuilder.DropTable(
                name: "AdditiveAdjustment");

            migrationBuilder.DropTable(
                name: "GrowLogs");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
