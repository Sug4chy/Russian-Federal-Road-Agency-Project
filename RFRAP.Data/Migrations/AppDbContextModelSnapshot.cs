﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RFRAP.Data.Context;

#nullable disable

namespace RFRAP.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RFRAP.Data.Entities.Advertisement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ExpirationDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastlyEditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoadId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoadId");

                    b.ToTable("advertisement", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("05513f6e-85bf-4454-9086-c243c2dc6441"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExpirationDateTime = new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MessageText = "На дороге всё спокойно, просто тестируем объявления",
                            RoadId = new Guid("0d396ef7-78e3-4980-9d78-a61df9ee1f89"),
                            Title = "Объявления для М-5"
                        });
                });

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

                    b.HasData(
                        new
                        {
                            Id = new Guid("0d396ef7-78e3-4980-9d78-a61df9ee1f89"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "М-5"
                        },
                        new
                        {
                            Id = new Guid("a1a5a180-1e8f-457b-b574-c6e227cb02fb"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "А-310"
                        },
                        new
                        {
                            Id = new Guid("37d115a0-10e8-444f-9379-78a231852962"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Р-254"
                        },
                        new
                        {
                            Id = new Guid("9d7a20b1-3b91-4d02-a3e5-c71ebab7d0e7"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Р-354"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Latitude1 = 0.0,
                            Latitude2 = 0.0,
                            Longitude1 = 0.0,
                            Longitude2 = 0.0,
                            RoadId = new Guid("0d396ef7-78e3-4980-9d78-a61df9ee1f89")
                        },
                        new
                        {
                            Id = new Guid("a5065dbf-417d-43d7-890b-2a5c64d930ac"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Latitude1 = 0.0,
                            Latitude2 = 0.0,
                            Longitude1 = 0.0,
                            Longitude2 = 0.0,
                            RoadId = new Guid("a1a5a180-1e8f-457b-b574-c6e227cb02fb")
                        },
                        new
                        {
                            Id = new Guid("c9db979a-5842-4783-9f49-6bfe049879ff"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Latitude1 = 0.0,
                            Latitude2 = 0.0,
                            Longitude1 = 0.0,
                            Longitude2 = 0.0,
                            RoadId = new Guid("37d115a0-10e8-444f-9379-78a231852962")
                        },
                        new
                        {
                            Id = new Guid("a72f8fff-f48c-4e34-ba60-d5e6b74e93df"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Latitude1 = 0.0,
                            Latitude2 = 0.0,
                            Longitude1 = 0.0,
                            Longitude2 = 0.0,
                            RoadId = new Guid("9d7a20b1-3b91-4d02-a3e5-c71ebab7d0e7")
                        });
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

            modelBuilder.Entity("RFRAP.Data.Entities.VerifiedPoint", b =>
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

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SegmentId");

                    b.ToTable("verified_point", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f1069ee4-14c5-4f96-99a6-6db1f251a4bc"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Latitude = 54.996371000000003,
                            Longitude = 61.133454,
                            Name = "Кафе Урал",
                            SegmentId = new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"),
                            Type = "Cafes"
                        },
                        new
                        {
                            Id = new Guid("403a8023-4711-4db0-9b99-8f80c2b99060"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Latitude = 54.989184000000002,
                            Longitude = 61.043416000000001,
                            Name = "Subway",
                            SegmentId = new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"),
                            Type = "Cafes"
                        },
                        new
                        {
                            Id = new Guid("40e0963e-676c-4b3e-87d6-b369222d774c"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Latitude = 54.987986999999997,
                            Longitude = 61.044195000000002,
                            Name = "РегионUNO",
                            SegmentId = new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"),
                            Type = "GasStations"
                        },
                        new
                        {
                            Id = new Guid("5ef5ef5a-ae4e-447a-94a2-c9d982d19e71"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Latitude = 54.945492999999999,
                            Longitude = 60.827627,
                            Name = "Salavat",
                            SegmentId = new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"),
                            Type = "GasStations"
                        },
                        new
                        {
                            Id = new Guid("ed7a038c-1dac-4b67-ac83-7c7933f73d45"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastlyEditedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Latitude = 55.233764999999998,
                            Longitude = 62.032693000000002,
                            Name = "Челябнефтепродукт",
                            SegmentId = new Guid("c9db979a-5842-4783-9f49-6bfe049879ff"),
                            Type = "GasStations"
                        });
                });

            modelBuilder.Entity("RFRAP.Data.Entities.Advertisement", b =>
                {
                    b.HasOne("RFRAP.Data.Entities.Road", "Road")
                        .WithMany("Advertisements")
                        .HasForeignKey("RoadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Road");
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

            modelBuilder.Entity("RFRAP.Data.Entities.VerifiedPoint", b =>
                {
                    b.HasOne("RFRAP.Data.Entities.Segment", "Segment")
                        .WithMany("VerifiedPoints")
                        .HasForeignKey("SegmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Segment");
                });

            modelBuilder.Entity("RFRAP.Data.Entities.Road", b =>
                {
                    b.Navigation("Advertisements");

                    b.Navigation("Segments");
                });

            modelBuilder.Entity("RFRAP.Data.Entities.Segment", b =>
                {
                    b.Navigation("UnverifiedPoints");

                    b.Navigation("VerifiedPoints");
                });

            modelBuilder.Entity("RFRAP.Data.Entities.UnverifiedPoint", b =>
                {
                    b.Navigation("File");
                });
#pragma warning restore 612, 618
        }
    }
}
