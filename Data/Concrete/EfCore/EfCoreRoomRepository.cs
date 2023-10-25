using Data.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;

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
                                    .Where(i=>i.Name == city)
                                    .AsQueryable();

            return await rooms.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
        }

    }
}