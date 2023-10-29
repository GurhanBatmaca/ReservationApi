using Data.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Data.Concrete.EfCore
{
    public class EfCoreRoomRepository : EfCoreGenericRepository<Room>,IRoomRepository
    {
        public EfCoreRoomRepository (ReservationContext context):base(context)
        {           
        }

        private ReservationContext? Context => _context as ReservationContext;

        public async Task<List<Room>> GetRoomsByCity(string city, int page,int pageSize)
        {
            var rooms =  Context!.Rooms
                                    .Include(i=>i.Hotel)
                                    .ThenInclude(i=>i!.City)
                                    .Where(i => i.Hotel!.City!.Name!.ToLower().Contains(city.ToLower()) && i.IsEmpty)
                                    .AsQueryable();


            return await rooms.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetRoomsCountByCity(string city)
        {
            var rooms =  Context!.Rooms
                                    .Include(i=>i.Hotel)
                                    .ThenInclude(i=>i!.City)
                                    .Where(i => i.Hotel!.City!.Name!.ToLower().Contains(city.ToLower()) && i.IsEmpty)
                                    .AsQueryable();

            return await rooms.CountAsync();
        }

        public async Task<List<Room>> GetRoomsByFilter(string? city, int minPrice, int maxPrice, int page, int pageSize)
        {
            var rooms =  Context!.Rooms
                                    .Include(i=>i.Hotel)
                                    .ThenInclude(i=>i!.City)
                                    .Where(i => i.IsEmpty && i.Price >= minPrice)
                                    .AsQueryable();

            if(!string.IsNullOrEmpty(city))
            {
                rooms = rooms.Where(i =>i.Hotel!.City!.Name!.ToLower().Contains(city.Trim().ToLower()));
            }
            if(maxPrice > 0)
            {
                rooms = rooms.Where(i =>i.Price <= maxPrice);
            }

            return await rooms.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
        }
        
        public async Task<int> GetRoomsCountByFilter(string? city, int minPrice, int maxPrice)
        {
            var rooms =  Context!.Rooms
                                    .Include(i=>i.Hotel)
                                    .ThenInclude(i=>i!.City)
                                    .Where(i => i.IsEmpty && i.Price >= minPrice)
                                    .AsQueryable();

            if(!string.IsNullOrEmpty(city))
            {
                rooms = rooms.Where(i =>i.Hotel!.City!.Name!.ToLower().Contains(city.ToLower()));
            }
            if(maxPrice > 0)
            {
                rooms = rooms.Where(i =>i.Price <= maxPrice);
            }

            return await rooms.CountAsync();
        }

        public async Task<List<Room>> GetRoomsByModel(RoomFilterModel model, int page, int pageSize)
        {
            var rooms =  Context!.Rooms
                                    .Include(i=>i.Hotel)
                                    .ThenInclude(i=>i!.City)
                                    .Where(i => i.IsEmpty && i.Price >= model.MinPrice)
                                    .AsQueryable();

            if(!string.IsNullOrEmpty(model.City))
            {
                rooms = rooms.Where(i =>i.Hotel!.City!.Name!.ToLower().Contains(model.City.Trim().ToLower()));
            }
            if(model.MaxPrice > 0)
            {
                rooms = rooms.Where(i =>i.Price <= model.MaxPrice);
            }

            if(DateTime.TryParse(model.EntryDate, out DateTime entryDate) && DateTime.TryParse(model.ReleaseDate, out DateTime releaseDate))
            {
               
                rooms = rooms.Where(i => (i.ReleaseDate != releaseDate) && (i.EntryDate != entryDate));
            }
              
            return await rooms.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();

        }
    
    }
}