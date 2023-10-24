﻿// <auto-generated />
using System;
using Data.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ReservationContext))]
    partial class ReservationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("CityId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            Name = "İstanbul"
                        },
                        new
                        {
                            CityId = 2,
                            Name = "İzmir"
                        },
                        new
                        {
                            CityId = 3,
                            Name = "Ankara"
                        },
                        new
                        {
                            CityId = 4,
                            Name = "Antalya"
                        },
                        new
                        {
                            CityId = 5,
                            Name = "Muğla"
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

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            Name = "Company 1"
                        },
                        new
                        {
                            CompanyId = 2,
                            Name = "Company 2"
                        },
                        new
                        {
                            CompanyId = 3,
                            Name = "Company 3"
                        },
                        new
                        {
                            CompanyId = 4,
                            Name = "Company 4"
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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RoomService")
                        .HasColumnType("bit");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoom")
                        .HasColumnType("int");

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
                            Name = "Swiss Hotel",
                            RoomService = true,
                            Stars = 5,
                            TotalRoom = 200
                        },
                        new
                        {
                            HotelId = 2,
                            AllInclusive = true,
                            CityId = 1,
                            CompanyId = 2,
                            Name = "Hilton Hotel",
                            RoomService = true,
                            Stars = 5,
                            TotalRoom = 200
                        },
                        new
                        {
                            HotelId = 3,
                            AllInclusive = true,
                            CityId = 2,
                            CompanyId = 3,
                            Name = "Garden Hotel",
                            RoomService = true,
                            Stars = 5,
                            TotalRoom = 200
                        },
                        new
                        {
                            HotelId = 4,
                            AllInclusive = true,
                            CityId = 2,
                            CompanyId = 4,
                            Name = "Plaza Hotel",
                            RoomService = true,
                            Stars = 5,
                            TotalRoom = 200
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
                            EntryDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestCapacity = 5,
                            HotelId = 1,
                            InnerRoomCount = 3,
                            IsEmpty = true,
                            Name = "King",
                            Price = 10000.0,
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
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
                            InnerRoomCount = 3,
                            IsEmpty = true,
                            Name = "Honeymoon",
                            Price = 10000.0,
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
                            InnerRoomCount = 3,
                            IsEmpty = true,
                            Name = "Honeymoon",
                            Price = 10000.0,
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