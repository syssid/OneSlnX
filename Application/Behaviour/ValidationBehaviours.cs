using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Behaviour
{
    public class ValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public ValidationBehaviours(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator.Any())
            {
                var validatorContxt = new ValidationContext<TRequest>(request);
                var result = await Task.WhenAll(_validator.Select(v => v.ValidateAsync(validatorContxt, cancellationToken)));

                var failures = result.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count > 0)
                    throw new ValidationException(failures);
            }
            var response = await next();

            return response;
        }
    }
}
