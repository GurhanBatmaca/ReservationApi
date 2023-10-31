using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Extentions
{
    public static class ModelBuilderExtention
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var hotels = new List<Hotel>
            {
                new Hotel {
                    HotelId=1,
                    Name="Swiss Hotel",
                    Stars=5,
                    TotalRoom=200,
                    RoomService=true,
                    AllInclusive=true,
                    CityId=1,
                    City = new City {CityId=1,Name="İstanbul"}
                },
                new Hotel {
                    HotelId=2,
                    Name="Hilton Hotel",
                    Stars=5,
                    TotalRoom=200,
                    RoomService=true,
                    AllInclusive=true
                },
                new Hotel {
                    HotelId=3,
                    Name="Garden Hotel",
                    Stars=5,
                    TotalRoom=200,
                    RoomService=true,
                    AllInclusive=true
                },
                new Hotel {
                    HotelId=3,
                    Name="Plaza Hotel",
                    Stars=5,
                    TotalRoom=200,
                    RoomService=true,
                    AllInclusive=true
                }
            };

            modelBuilder.Entity<Room>().HasData
            (
                new Room 
                {
                    RoomId=1,
                    RoomNumber=1,
                    Name="King",
                    Price= 20000,
                    Discount=0,
                    SquareMeters=150,
                    BedsCount=4,
                    IsEmpty=true,
                    GuestCapacity=5,
                    InnerRoomCount=3,
                    Tv=true,
                    HotelId=1,
                    ImageUrl = "room-1.jpg",
                    EntryDate = DateTime.Now.AddDays(-3),
                    ReleaseDate = DateTime.Now.AddDays(-1),
                },
                new Room 
                {
                    RoomId=2,
                    RoomNumber=2,
                    Name="Honeymoon",
                    Price= 15000,
                    Discount=0,
                    SquareMeters=150,
                    BedsCount=4,
                    IsEmpty=true,
                    GuestCapacity=5,
                    InnerRoomCount=3,
                    Tv=true,
                    HotelId=1,
                    ImageUrl = "room-2.jpg"
                },
                new Room 
                {
                    RoomId=3,
                    RoomNumber=1,
                    Name="Honeymoon",
                    Price= 15000,
                    Discount=0,
                    SquareMeters=150,
                    BedsCount=4,
                    IsEmpty=true,
                    GuestCapacity=5,
                    InnerRoomCount=3,
                    Tv=true,
                    HotelId=2,
                    ImageUrl = "room-3.jpg"
                },
                new Room 
                {
                    RoomId=4,
                    RoomNumber=2,
                    Name="Standart",
                    Price= 10000,
                    Discount=0,
                    SquareMeters=150,
                    BedsCount=4,
                    IsEmpty=true,
                    GuestCapacity=5,
                    InnerRoomCount=3,
                    Tv=true,
                    HotelId=2,
                    ImageUrl = "room-4.jpg"
                }
            );

            modelBuilder.Entity<Hotel>().HasData
            (
                new Hotel {
                    HotelId=1,
                    Name="Swiss Hotel",
                    Stars=5,
                    TotalRoom=200,
                    RoomService=true,
                    AllInclusive=true,
                    CityId=1,
                    CompanyId=1,
                    ImageUrl = "hotel-1.jpg",
                    IsHome=true,
                    Url = "swiss-hotel"
                },
                new Hotel {
                    HotelId=2,
                    Name="Hilton Hotel",
                    Stars=5,
                    TotalRoom=200,
                    RoomService=true,
                    AllInclusive=true,
                    CityId=1,
                    CompanyId=2,
                    ImageUrl = "hotel-2.jpg",
                    IsHome=true,
                    Url = "hilton-hotel"
                },
                new Hotel {
                    HotelId=3,
                    Name="Garden Hotel",
                    Stars=5,
                    TotalRoom=200,
                    RoomService=true,
                    AllInclusive=true,
                    CityId=2,
                    CompanyId=3,
                    ImageUrl = "hotel-3.jpg",
                    IsHome=true,
                    Url = "garden-hotel"
                },
                new Hotel {
                    HotelId=4,
                    Name="Plaza Hotel",
                    Stars=5,
                    TotalRoom=200,
                    RoomService=true,
                    AllInclusive=true,
                    CityId=2,
                    CompanyId=4,
                    ImageUrl = "hotel-4.jpg",
                    Url = "plaza-hotel"
                }
            );

            modelBuilder.Entity<Company>().HasData
            (
                new Company { CompanyId =1,Name="Company 1",Url="company-1"},
                new Company { CompanyId =2,Name="Company 2",Url="company-2"},
                new Company { CompanyId =3,Name="Company 3",Url="company-3"},
                new Company { CompanyId =4,Name="Company 4",Url="company-4"}
            );

            modelBuilder.Entity<City>().HasData
            (
                new City {CityId=1,Name="İstanbul",Url="istanbul"},
                new City {CityId=2,Name="İzmir",Url="izmir"},
                new City {CityId=3,Name="Ankara",Url="ankara"},
                new City {CityId=4,Name="Antalya",Url="antalya"},
                new City {CityId=5,Name="Muğla",Url="mugla"}
            );
        }
    }
}