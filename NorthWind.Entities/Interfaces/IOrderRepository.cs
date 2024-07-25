using NorthWind.Entities.POCOEntitites;
using NorthWind.Entities.Specifications;

namespace NorthWind.Entities.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        IEnumerable<Order> GetOrderBySpecification(Specification<Order> specifications);
    }
}
