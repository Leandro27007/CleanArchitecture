using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntitites;
using NorthWind.Entities.Specifications;
using NorthWind.Repositories.EFCore.DataContext;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NorthWindContext _context;
        public OrderRepository(NorthWindContext context)
        {
            _context = context;
        }

        public void Create(Order order)
        {
            _context.Add(order);
        }


        //Se utiliza el patron SPECIFICATION para establecer criterios de busqueda de manera flexible y avanzada
        public IEnumerable<Order> GetOrderBySpecification(Specification<Order> specifications)
        {
            //Esta expression de tipo Expresion<func<T,bool>> se convierte a un delegado el cual es tipo Func<T,bool>
            var ExpressionDelegate = specifications.Expression.Compile();

            //Aqui se ejecuta el delegado, Where() es quien ejecuta el delegado.
            return _context.Orders.Where(ExpressionDelegate);
        }
    }
}
