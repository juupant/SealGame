﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SealGame.Data;

#nullable disable

namespace SealGame.Data.Migrations
{
    [DbContext(typeof(DatabaseTaskDbContext))]
    [Migration("20241119132359_asd")]
    partial class asd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SealGame.Core.Domain.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("EffectAmount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("SealGame.Core.Domain.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<int>("DailyTasksCompleted")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SealGame.Core.Domain.Seal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cleanliness")
                        .HasColumnType("int");

                    b.Property<int>("Enrichment")
                        .HasColumnType("int");

                    b.Property<int>("Happiness")
                        .HasColumnType("int");

                    b.Property<int>("Hunger")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Seals");
                });

            modelBuilder.Entity("SealGame.Core.Domain.SealSpecies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxCleanliness")
                        .HasColumnType("int");

                    b.Property<int>("MaxEnrichment")
                        .HasColumnType("int");

                    b.Property<int>("MaxHappiness")
                        .HasColumnType("int");

                    b.Property<int>("MaxHunger")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SealSpecies");
                });

            modelBuilder.Entity("SealGame.Core.Domain.Item", b =>
                {
                    b.HasOne("SealGame.Core.Domain.Player", null)
                        .WithMany("Inventory")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("SealGame.Core.Domain.Seal", b =>
                {
                    b.HasOne("SealGame.Core.Domain.Player", null)
                        .WithMany("SealsOwned")
                        .HasForeignKey("PlayerId");

                    b.HasOne("SealGame.Core.Domain.SealSpecies", "Species")
                        .WithMany("Seals")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Species");
                });

            modelBuilder.Entity("SealGame.Core.Domain.Player", b =>
                {
                    b.Navigation("Inventory");

                    b.Navigation("SealsOwned");
                });

            modelBuilder.Entity("SealGame.Core.Domain.SealSpecies", b =>
                {
                    b.Navigation("Seals");
                });
#pragma warning restore 612, 618
        }
    }
}
