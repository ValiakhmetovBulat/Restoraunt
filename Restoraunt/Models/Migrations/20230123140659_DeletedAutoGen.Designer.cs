﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Restoraunt.Models;

#nullable disable

namespace Restoraunt.Migrations
{
    [DbContext(typeof(RestorauntDbContext))]
    [Migration("20230123140659_DeletedAutoGen")]
    partial class DeletedAutoGen
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("Restoraunt.Data.Entities.MenuPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("PositionTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PositionTypeId");

                    b.ToTable("MenuPositions");
                });

            modelBuilder.Entity("Restoraunt.Data.Entities.PositionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("SectionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("PositionTypes");
                });

            modelBuilder.Entity("Restoraunt.Data.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Restoraunt.Data.Entities.MenuPosition", b =>
                {
                    b.HasOne("Restoraunt.Data.Entities.PositionType", null)
                        .WithMany("MenuPositions")
                        .HasForeignKey("PositionTypeId");
                });

            modelBuilder.Entity("Restoraunt.Data.Entities.PositionType", b =>
                {
                    b.HasOne("Restoraunt.Data.Entities.Section", null)
                        .WithMany("PositionTypes")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("Restoraunt.Data.Entities.PositionType", b =>
                {
                    b.Navigation("MenuPositions");
                });

            modelBuilder.Entity("Restoraunt.Data.Entities.Section", b =>
                {
                    b.Navigation("PositionTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
