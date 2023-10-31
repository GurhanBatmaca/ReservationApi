﻿// <auto-generated />
using System;
using Data.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ReservationContext))]
    [Migration("20231031183220_AddColumn")]
    partial class AddColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            Name = "İstanbul",
                            Url = "istanbul"
                        },
                        new
                        {
                            CityId = 2,
                            Name = "İzmir",
                            Url = "izmir"
                        },
                        new
                        {
                            CityId = 3,
                            Name = "Ankara",
                            Url = "ankara"
                        },
                        new
                        {
                            CityId = 4,
                            Name = "Antalya",
                            Url = "antalya"
                        },
                        new
                        {
                            CityId = 5,
                            Name = "Muğla",
                            Url = "mugla"
                        });
                });

            modelBuilder.Entity("Entity.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            Name = "Company 1",
                            Url = "company-1"
                        },
                        new
                        {
                            CompanyId = 2,
                            Name = "Company 2",
                            Url = "company-2"
                        },
                        new
                        {
                            CompanyId = 3,
                            Name = "Company 3",
                            Url = "company-3"
                        },
                        new
                        {
                            CompanyId = 4,
                            Name = "Company 4",
                            Url = "company-4"
                        });
                });

            modelBuilder.Entity("Entity.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"));

                    b.Property<bool>("AllInclusive")
                        .HasColumnType("bit");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHome")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RoomService")
                        .HasColumnType("bit");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoom")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelId");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            HotelId = 1,
                            AllInclusive = true,
                            CityId = 1,
                            CompanyId = 1,
                            ImageUrl = "hotel-1.jpg",
                            IsHome = true,
                            Name = "Swiss Hotel",
                            RoomService = true,
                            Stars = 5,
                            TotalRoom = 200,
                            Url = "swiss-hotel"
                        },
                        new
                        {
                            HotelId = 2,
                            AllInclusive = true,
                            CityId = 1,
                            CompanyId = 2,
                            ImageUrl = "hotel-2.jpg",
                            IsHome = true,
                            Name = "Hilton Hotel",
                            RoomService = true,
                            Stars = 5,
                            TotalRoom = 200,
                            Url = "hilton-hotel"
                        },
                        new
                        {
                            HotelId = 3,
                            AllInclusive = true,
                            CityId = 2,
                            CompanyId = 3,
                            ImageUrl = "hotel-3.jpg",
                            IsHome = true,
                            Name = "Garden Hotel",
                            RoomService = true,
                            Stars = 5,
                            TotalRoom = 200,
                            Url = "garden-hotel"
                        },
                        new
                        {
                            HotelId = 4,
                            AllInclusive = true,
                            CityId = 2,
                            CompanyId = 4,
                            ImageUrl = "hotel-4.jpg",
                            IsHome = false,
                            Name = "Plaza Hotel",
                            RoomService = true,
                            Stars = 5,
                            TotalRoom = 200,
                            Url = "plaza-hotel"
                        });
                });

            modelBuilder.Entity("Entity.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int>("BedsCount")
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuestCapacity")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InnerRoomCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsEmpty")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<int>("SquareMeters")
                        .HasColumnType("int");

                    b.Property<bool>("Tv")
                        .HasColumnType("bit");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            BedsCount = 4,
                            Discount = 0.0,
                            EntryDate = new DateTime(2023, 10, 28, 21, 32, 20, 393, DateTimeKind.Local).AddTicks(8826),
                            GuestCapacity = 5,
                            HotelId = 1,
                            ImageUrl = "room-1.jpg",
                            InnerRoomCount = 3,
                            IsEmpty = true,
                            Name = "King",
                            Price = 20000.0,
                            ReleaseDate = new DateTime(2023, 10, 30, 21, 32, 20, 393, DateTimeKind.Local).AddTicks(8838),
                            RoomNumber = 1,
                            SquareMeters = 150,
                            Tv = true
                        },
                        new
                        {
                            RoomId = 2,
                            BedsCount = 4,
                            Discount = 0.0,
                            EntryDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestCapacity = 5,
                            HotelId = 1,
                            ImageUrl = "room-2.jpg",
                            InnerRoomCount = 3,
                            IsEmpty = true,
                            Name = "Honeymoon",
                            Price = 15000.0,
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomNumber = 2,
                            SquareMeters = 150,
                            Tv = true
                        },
                        new
                        {
                            RoomId = 3,
                            BedsCount = 4,
                            Discount = 0.0,
                            EntryDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestCapacity = 5,
                            HotelId = 2,
                            ImageUrl = "room-3.jpg",
                            InnerRoomCount = 3,
                            IsEmpty = true,
                            Name = "Honeymoon",
                            Price = 15000.0,
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomNumber = 1,
                            SquareMeters = 150,
                            Tv = true
                        },
                        new
                        {
                            RoomId = 4,
                            BedsCount = 4,
                            Discount = 0.0,
                            EntryDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestCapacity = 5,
                            HotelId = 2,
                            ImageUrl = "room-4.jpg",
                            InnerRoomCount = 3,
                            IsEmpty = true,
                            Name = "Standart",
                            Price = 10000.0,
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomNumber = 2,
                            SquareMeters = 150,
                            Tv = true
                        });
                });

            modelBuilder.Entity("Entity.Hotel", b =>
                {
                    b.HasOne("Entity.City", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Company", "Company")
                        .WithMany("Hotels")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Entity.Room", b =>
                {
                    b.HasOne("Entity.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Entity.City", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("Entity.Company", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("Entity.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
