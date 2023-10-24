using Data.Abstract;
using Entity;

namespace Data.Concrete.EfCore
{
    public class EfCoreCompanyRepository : EfCoreGenericRepository<Company>,ICompanyRepository
    {
        public EfCoreCompanyRepository (ReservationContext context):base(context)
        {           
        }

        private ReservationContext? Context => _context as ReservationContext;
        
    }
}