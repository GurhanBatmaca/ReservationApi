using Microsoft.EntityFrameworkCore;

namespace Data.Concrete
{
    public class ReservationContext: DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options):base(options)
        {
            
        }
        
    }
}