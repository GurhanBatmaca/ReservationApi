using Data.Abstract;
using Entity;

namespace Data.Concrete.EfCore
{
    public class EfCoreHotelRepository: EfCoreGenericRepository<Hotel>,IHotelRepository
    {
        public EfCoreHotelRepository(ReservationContext context):base(context)
        {           
        }

        private ReservationContext? Context => _context as ReservationContext;
        
    }
}