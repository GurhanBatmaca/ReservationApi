using Data.Abstract;
using Entity;

namespace Data
{
    public interface IUnitOfWork: IDisposable
    {
        ICityRepository Citys {get;}
        ICompanyRepository Companys {get;}
        IHotelRepository Hotels {get;}
        IRoomRepository Rooms {get;}
    }
}