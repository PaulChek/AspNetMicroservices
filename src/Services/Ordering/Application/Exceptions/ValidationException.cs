using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions {
    public class ValidationException : ApplicationException {
        public Dictionary<string, string[]> Errors { get; set; }
        public ValidationException() : base("[ERROR_VALID] One or more validations failed") {
            Errors = new();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this() {
            Errors = failures
                .GroupBy(f => f.PropertyName, f => f.ErrorMessage)
                .ToDictionary(f => f.Key, f => f.ToArray());
        }
    }
}
