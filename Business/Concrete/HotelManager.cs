using Entity;

namespace Business.Abstract
{
    public class HotelManager : IHotelService
    {
        public Task<List<Hotel>> GetHomePageHotels(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

    }
}