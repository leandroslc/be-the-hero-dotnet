using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeTheHero.Essential.Results;

namespace BeTheHero.Essential
{
    public abstract class Command
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
    }
}
