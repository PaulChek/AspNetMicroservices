using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands {
    public class DeleteValidator : AbstractValidator<Delete.Command> {
        public DeleteValidator() {
            RuleFor(c => c.Id).NotNull().WithMessage("{Id} - id can't be null!");
        }
    }
}
