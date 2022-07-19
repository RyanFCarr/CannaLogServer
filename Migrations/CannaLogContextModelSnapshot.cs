﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Contexts;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(CannaLogContext))]
    partial class CannaLogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Server.Models.Additive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Additives");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "General Hydroponics",
                            Name = "Micro",
                            Type = "NUTES"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "General Hydroponics",
                            Name = "Bloom",
                            Type = "NUTES"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "General Hydroponics",
                            Name = "CaliMag",
                            Type = "NUTES"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "General Hydroponics",
                            Name = "PH Up",
                            Type = "PH"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "General Hydroponics",
                            Name = "PH Down",
                            Type = "PH"
                        },
                        new
                        {
                            Id = 6,
                            Brand = "Botanicare",
                            Name = "Hydroguard",
                            Type = "ROOT SUPPLEMENT"
                        });
                });

            modelBuilder.Entity("Server.Models.AdditiveAdjustment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FinalPPM")
                        .HasColumnType("int");

                    b.Property<int?>("GrowLogId")
                        .HasColumnType("int");

                    b.Property<int>("InitialPPM")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrowLogId");

                    b.ToTable("AdditiveAdjustments");
                });

            modelBuilder.Entity("Server.Models.AdditiveDosage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdditiveAdjustmentId")
                        .HasColumnType("int");

                    b.Property<int>("AdditiveId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasPrecision(8, 3)
                        .HasColumnType("decimal(8,3)");

                    b.Property<string>("UnitofMeasure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdditiveAdjustmentId");

                    b.HasIndex("AdditiveId");

                    b.ToTable("AdditiveDosages");
                });

            modelBuilder.Entity("Server.Models.GrowLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("AirTemperature")
                        .HasPrecision(4, 1)
                        .HasColumnType("decimal(4,1)");

                    b.Property<decimal>("FinalPH")
                        .HasPrecision(3, 1)
                        .HasColumnType("decimal(3,1)");

                    b.Property<int>("FinalPPM")
                        .HasColumnType("int");

                    b.Property<decimal?>("GrowMediumTemperature")
                        .HasPrecision(4, 1)
                        .HasColumnType("decimal(4,1)");

                    b.Property<decimal?>("Humidity")
                        .HasPrecision(3, 1)
                        .HasColumnType("decimal(3,1)");

                    b.Property<decimal>("InitialPH")
                        .HasPrecision(3, 1)
                        .HasColumnType("decimal(3,1)");

                    b.Property<int>("InitialPPM")
                        .HasColumnType("int");

                    b.Property<decimal?>("LightHeight")
                        .HasPrecision(4, 1)
                        .HasColumnType("decimal(4,1)");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlantAge")
                        .HasColumnType("int");

                    b.Property<decimal?>("PlantHeight")
                        .HasPrecision(4, 1)
                        .HasColumnType("decimal(4,1)");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("GrowLogs");
                });

            modelBuilder.Entity("Server.Models.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Age")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasComputedColumnSql("CASE WHEN TransplantDate IS NULL THEN NULL ELSE DATEDIFF(DAY, TransplantDate, COALESCE(HarvestDate, GETDATE())) END");

                    b.Property<string>("BaseNutrientsBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Breeder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrowMedium")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrowType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("HarvestDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFeminized")
                        .HasColumnType("bit");

                    b.Property<string>("LightingSchedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LightingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TargetPH")
                        .HasPrecision(3, 1)
                        .HasColumnType("decimal(3,1)");

                    b.Property<string>("TerminationReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TransplantDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("Server.Models.AdditiveAdjustment", b =>
                {
                    b.HasOne("Server.Models.GrowLog", null)
                        .WithMany("AdditiveAdjustments")
                        .HasForeignKey("GrowLogId");
                });

            modelBuilder.Entity("Server.Models.AdditiveDosage", b =>
                {
                    b.HasOne("Server.Models.AdditiveAdjustment", null)
                        .WithMany("Dosages")
                        .HasForeignKey("AdditiveAdjustmentId");

                    b.HasOne("Server.Models.Additive", "Additive")
                        .WithMany()
                        .HasForeignKey("AdditiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Additive");
                });

            modelBuilder.Entity("Server.Models.GrowLog", b =>
                {
                    b.HasOne("Server.Models.Plant", "Plant")
                        .WithMany("GrowLogs")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("Server.Models.AdditiveAdjustment", b =>
                {
                    b.Navigation("Dosages");
                });

            modelBuilder.Entity("Server.Models.GrowLog", b =>
                {
                    b.Navigation("AdditiveAdjustments");
                });

            modelBuilder.Entity("Server.Models.Plant", b =>
                {
                    b.Navigation("GrowLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
