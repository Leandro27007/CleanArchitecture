using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntitites;
using NorthWind.Repositories.EFCore.DataContext;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly NorthWindContext _context;
        public OrderDetailRepository(NorthWindContext context)
        {
            _context = context;
        }
        public void Create(OrderDetail orderDetail)
        {
            _context.Add(orderDetail);
        }
    }
}
