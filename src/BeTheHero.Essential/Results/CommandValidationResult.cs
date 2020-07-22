using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeTheHero.Essential.Results
{
    public sealed class CommandValidationResult : Result
    {
        public CommandValidationResult(
            bool ok,
            IReadOnlyCollection<ValidationResult> errors)
            : base(ok)
        {
            Errors = errors ?? new HashSet<ValidationResult>();
        }

        public static CommandValidationResult Invalid => new CommandValidationResult(false, null);

        public IReadOnlyCollection<ValidationResult> Errors { get; }
    }
}
