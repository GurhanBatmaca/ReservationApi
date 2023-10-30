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
  
        public async Task<List<Room>> GetRoomsBySearch(RoomFilterModel model, int page, int pageSize)
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
               
                rooms = rooms.Where(i => i.EntryDate.Date != entryDate.Date && i.ReleaseDate.Date != releaseDate.Date );
            }
              
            return await rooms.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();

        }

        public async Task<int> GetRoomsCountBySearch(RoomFilterModel model)
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
               
                rooms = rooms.Where(i => i.EntryDate.Date != entryDate.Date && i.ReleaseDate.Date != releaseDate.Date );
            }
              
            return await rooms.CountAsync();
        }

        public async Task<List<Room>> GetAllRooms(int page, int pageSize)
        {
            var rooms = Context!.Rooms
                                .Include(i=>i.Hotel)
                                .ThenInclude(i=>i!.City)
                                .AsQueryable();

            return await rooms.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetAllRoomsCount()
        {
            var rooms = Context!.Rooms
                                .Include(i=>i.Hotel)
                                .ThenInclude(i=>i!.City)
                                .AsQueryable();

            return await rooms.CountAsync();
        }

    }
}