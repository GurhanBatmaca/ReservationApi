using Data.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EfCore
{
    public class EfCoreHotelRepository: EfCoreGenericRepository<Hotel>,IHotelRepository
    {
        public EfCoreHotelRepository(ReservationContext context):base(context)
        {           
        }

        private ReservationContext? Context => _context as ReservationContext;

        public async Task<List<Hotel>> GetAllHotels(int page, int pageSize)
        {
            var hotels = Context!.Hotels
                                .Include(i=>i.City)
                                .Include(i=>i.Company)
                                .AsQueryable();

            return await hotels.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetAllHotelsCount()
        {
            return await Context!.Hotels
                                .CountAsync();

        }


        public async Task<List<Hotel>> GetHomePageHotels(int page, int pageSize)
        {
            var hotels = Context!.Hotels
                                .Include(i=>i.City)
                                .Include(i=>i.Company)
                                .Where(i=>i.IsHome)
                                .AsQueryable();

            return await hotels.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetHomePageHotelsCount()
        {
            return await Context!.Hotels
                                .Where(i=>i.IsHome)
                                .CountAsync();
        }
    }
}