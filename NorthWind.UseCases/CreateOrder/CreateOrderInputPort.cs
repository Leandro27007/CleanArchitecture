using MediatR;
using NorthWind.UseCasesDTOs.CreateOrder;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInputPort : CreateOrderParams, IRequest<int>
    {
    }
}
