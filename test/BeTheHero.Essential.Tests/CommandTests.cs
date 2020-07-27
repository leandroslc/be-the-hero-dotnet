using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;

namespace BeTheHero.Essential.Tests
{
    public class CommandTests
    {
        [Test]
        public void Validate_should_return_ok_when_valid()
        {
            var command = new TestCommand
            {
                Name = "Test",
                Email = "test@test.com",
            };

            var result = command.Validate();

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Errors, Is.Empty);
        }

        [Test]
        public void Validate_should_return_errors_when_invalid()
        {
            var command = new TestCommand
            {
                Name = "Test",
                Email = "not_valid_email",
            };

            var result = command.Validate();

            Assert.That(result.Ok, Is.False);
            Assert.That(result.Errors.Count, Is.EqualTo(1));
            Assert.That(result.Errors.First().MemberNames, Does.Contain("Email"));
        }

        public void Validate_with_custom_validation_should_return_errors_when_invalid()
        {
            var command = new TestCommandWithCustomValidation();

            var result = command.Validate();

            Assert.That(result.Ok, Is.False);
            Assert.That(result.Errors.Count, Is.EqualTo(1));
            Assert.That(result.Errors.First().MemberNames, Does.Contain("Name"));
        }

        private class TestCommand : Command
        {
            [Required]
            public string Name { get; set; }

            [EmailAddress]
            public string Email { get; set; }
        }

        private class TestCommandWithCustomValidation : Command
        {
            public string Name { get; set; }

            protected override IEnumerable<ValidationResult> GetValidations(ValidationContext context)
            {
                if (Name == null)
                {
                    yield return new ValidationResult("Name is null", new [] {"Name"});
                }
            }
        }
    }
}
