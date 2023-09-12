using FluentValidation;
using MediatR_CQRS.Commands;

namespace MediatR_CQRS.Validations
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        /// <summary>
        /// we can inject in constructor something like IOrderRepository to check if order exist with name before or notS
        /// </summary>
        public CreateOrderCommandValidator()
        {
            //RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3);


        }
    }
}
