using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BeTheHero.Essential.Results;

namespace BeTheHero.Essential
{
    public abstract class Command : IValidatableObject
    {
        public CommandValidationResult Validate()
        {
            var context = new ValidationContext(this);
            var errors = new List<ValidationResult>();

            var ok = Validator.TryValidateObject(
                instance: this,
                validationContext: context,
                validationResults: errors,
                validateAllProperties: true);

            return new CommandValidationResult(ok, errors);
        }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext context)
            => GetValidations(context);

        protected virtual IEnumerable<ValidationResult> GetValidations(ValidationContext context)
            => Enumerable.Empty<ValidationResult>();
    }
}
