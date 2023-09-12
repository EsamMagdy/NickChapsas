using FluentValidation;
using MediatR;

namespace MediatR_CQRS.PipelineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
                _validator = validator;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // pre
            var context = new ValidationContext<TRequest>(request);

            var faliures = _validator
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(s => s != null)
                .ToList();

            if(faliures.Any())
            {
                // it not prefer to throw an exception instead of return TResponse
                throw new ValidationException(faliures);
            }
            // next();

            return await next();
            // post
        }
    }
}
