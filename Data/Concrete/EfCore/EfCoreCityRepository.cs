using Data.Abstract;
using Entity;

namespace Data.Concrete.EfCore
{
    public class EfCoreCityRepository: EfCoreGenericRepository<City>,ICityRepository
    {
        public EfCoreCityRepository(ReservationContext context):base(context)
        {           
        }

        private ReservationContext? Context => _context as ReservationContext;
        
    }
}