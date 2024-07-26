using FluentValidation;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.CustumerId).NotEmpty()
                    .WithMessage("Debe proporcionar el identificador del cliente.");
            RuleFor(c => c.ShipAddress).NotEmpty()
                .WithMessage("Debe proporcionar direccion de envio.");
            RuleFor(c => c.ShipCity).NotEmpty()
                .MinimumLength(3)
                .WithMessage("Debe proporcionar al menos 3 caracteres del nombre de la ciudad.");
            RuleFor(c => c.ShipCountry).NotEmpty()
                .MinimumLength(3)
                 .WithMessage("Debe proporcionar al menos 3 caracteres del nombre del pais.");
            RuleFor(c => c.OrderDetails).Must(d => d != null && d.Any())
                .WithMessage("Deben especificarse los productos de la orden.");
        }
    }
}
