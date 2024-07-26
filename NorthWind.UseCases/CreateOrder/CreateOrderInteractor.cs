using MediatR;
using NorthWind.Entities.Enums;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntitites;

namespace NorthWind.UseCases.CreateOrder
{

    //EN ESTA CLASE SE IMPLEMENTA EL CASO DE USO (Logica de negocio).

    //SE UTILIZA MEDIATR PARA MANEJAR LA SOLICITUD.

    public class CreateOrderInteractor : IRequestHandler<CreateOrderInputPort, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private IUnitOfWork _unitOfWork;
        public CreateOrderInteractor(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateOrderInputPort request, CancellationToken cancellationToken)
        {
            Order order = new Order() 
            { 
              CustomerID = request.CustumerId,
              OrderDate = DateTime.UtcNow,
              ShipAddress = request.ShipAddress,
              ShipCountry = request.ShipCountry,
              ShipCity = request.ShipCity,
              ShipPostalCode = request.ShipPostalCode,
              ShippingType = ShippingType.Road,
              DiscountType = DiscountType.Percentage,
              Discount = 10
            };

            _orderRepository.Create(order);

            foreach (var item in request.OrderDetails)
            {
                _orderDetailRepository.Create(
                    new OrderDetail()
                    {
                        Order = order,
                        ProductId = item.ProductId,
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity,
                    });
            }

            try
            {
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralExceptions("Error al crear la orden.", ex.Message);
            }
            return order.Id;

        }
    }
}
