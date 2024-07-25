using NorthWind.Entities.POCOEntitites;

namespace NorthWind.Entities.Interfaces
{
    public interface IOrderDetailRepository
    {
        void Create(OrderDetail orderDetail);
    }
}
