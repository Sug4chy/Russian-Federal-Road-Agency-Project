﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RFRAP.Data.Context;

#nullable disable

namespace RFRAP.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240217075836_AddedStringConversationToUnverifiedPointType")]
    partial class AddedStringConversationToUnverifiedPointType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RFRAP.Data.Entities.AttachmentFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastlyEditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PointId")
                        .HasColumnType("uuid");

                    b.Property<string>("UniqueName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasAlternateKey("UniqueName");

                    b.HasIndex("PointId")
                        .IsUnique();

                    b.ToTable("attachment_file", (string)null);
                });

            modelBuilder.Entity("RFRAP.Data.Entities.GasStation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastlyEditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SegmentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SegmentId");

                    b.ToTable("gas_station", (string)null);
                });

            modelBuilder.Entity("RFRAP.Data.Entities.Road", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastlyEditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("road", (string)null);
                });

            modelBuilder.Entity("RFRAP.Data.Entities.Segment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastlyEditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Latitude1")
                        .HasColumnType("double precision");

                    b.Property<double>("Latitude2")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude1")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude2")
                        .HasColumnType("double precision");

                    b.Property<Guid>("RoadId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoadId");

                    b.ToTable("segment", (string)null);
                });

            modelBuilder.Entity("RFRAP.Data.Entities.UnverifiedPoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastlyEditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<Guid>("SegmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SegmentId");

                    b.ToTable("unverified_point", (string)null);
                });

            modelBuilder.Entity("RFRAP.Data.Entities.AttachmentFile", b =>
                {
                    b.HasOne("RFRAP.Data.Entities.UnverifiedPoint", "Point")
                        .WithOne("File")
                        .HasForeignKey("RFRAP.Data.Entities.AttachmentFile", "PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Point");
                });

            modelBuilder.Entity("RFRAP.Data.Entities.GasStation", b =>
                {
                    b.HasOne("RFRAP.Data.Entities.Segment", "Segment")
                        .WithMany("GasStations")
                        .HasForeignKey("SegmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Segment");
                });

            modelBuilder.Entity("RFRAP.Data.Entities.Segment", b =>
                {
                    b.HasOne("RFRAP.Data.Entities.Road", "Road")
                        .WithMany("Segments")
                        .HasForeignKey("RoadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Road");
                });

            modelBuilder.Entity("RFRAP.Data.Entities.UnverifiedPoint", b =>
                {
                    b.HasOne("RFRAP.Data.Entities.Segment", "Segment")
                        .WithMany("UnverifiedPoints")
                        .HasForeignKey("SegmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Segment");
                });

            modelBuilder.Entity("RFRAP.Data.Entities.Road", b =>
                {
                    b.Navigation("Segments");
                });

            modelBuilder.Entity("RFRAP.Data.Entities.Segment", b =>
                {
                    b.Navigation("GasStations");

                    b.Navigation("UnverifiedPoints");
                });

            modelBuilder.Entity("RFRAP.Data.Entities.UnverifiedPoint", b =>
                {
                    b.Navigation("File");
                });
#pragma warning restore 612, 618
        }
    }
}