using FluentValidation;
using MediatR;

namespace NorthWind.UseCases.Common.Behaviors
{

    public class ValidationBehaivor<TRequest, TResponse>:
        //La interfaz IPipelineBehavior de Mediatr, permite insertar logica, en este caso logica de
        //...validacion antes y/o despues de que un manejador de solicitudes procese la solicitud.
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaivor(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var Failures = _validators.Select(v => v.Validate(request))
                                       .SelectMany(r => r.Errors)
                                       .Where(f => f != null)
                                       .ToList();

            if (Failures.Any()) 
            {
                throw new ValidationException(Failures);
            }

            return next();
        }

        //EL FLUJO SERIA EL SIGUIENTE: 
        /*
         Inyección de Dependencias:
            Los validadores de solicitudes se inyectan en el ValidationBehavior.

        Validación:
        Cuando una solicitud se maneja, el ValidationBehavior se ejecuta primero. 
        Valida la solicitud utilizando todos los validadores aplicables.

        Manejo de Errores:
        Si hay errores de validación, se lanza una excepción. Si no hay errores, 
        la solicitud pasa al siguiente manejador en la cadena.
         */
    }
}
