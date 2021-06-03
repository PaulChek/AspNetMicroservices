using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands {
    public class CheckOutValidator : AbstractValidator<CheckOut.Command> {
        public CheckOutValidator() {
            RuleFor(p => p.OrderVm.FirstName)
                .NotEmpty().WithMessage("{FirstName} is Requered")
                .MaximumLength(25);
        }
    }
}
