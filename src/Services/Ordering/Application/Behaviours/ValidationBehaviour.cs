using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.Behaviours {
    public class ValidationBehaviour<TReq, TRes> : IPipelineBehavior<TReq, TRes> {
        private readonly IEnumerable<IValidator<TReq>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TReq>> validators) {
            _validators = validators;
        }

        public async Task<TRes> Handle(TReq request, CancellationToken cancellationToken, RequestHandlerDelegate<TRes> next) {
            if (!_validators.Any()) return await next();

            var context = new ValidationContext<TReq>(request);

            var validationResults = await Task.WhenAll(
                         _validators.Select(v => v.ValidateAsync(context, cancellationToken))
                );

            var failures = validationResults.SelectMany(r => r.Errors).Where(r => r != null);

            if (failures.Any())
                throw new ValidationException(failures);

            return await next();

        }
    }
}
