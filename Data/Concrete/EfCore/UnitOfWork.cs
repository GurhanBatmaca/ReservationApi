using Data.Abstract;

namespace Data.Concrete.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReservationContext _context;
        public UnitOfWork(ReservationContext context)
        {
            _context = context;
        }

        private EfCoreCityRepository? cityRepository;
        private EfCoreCompanyRepository? companyRepository;
        private EfCoreHotelRepository? hotelRepository;
        private EfCoreRoomRepository? roomRepository;
        public IHotelRepository Hotels => hotelRepository ??= new EfCoreHotelRepository(_context);

        public ICityRepository Citys => cityRepository ??= new EfCoreCityRepository(_context);

        public ICompanyRepository Companys => companyRepository ??= new EfCoreCompanyRepository(_context);

        public IRoomRepository Rooms => roomRepository ??= new EfCoreRoomRepository(_context);


        public void Dispose() => _context.Dispose();

    }
}