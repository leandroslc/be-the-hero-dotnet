using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

namespace BeTheHero.Essential.Results.Tests
{
    public class CommandValidationResultTests
    {
        [Test]
        public void Should_create_result_with_errors()
        {
            // Given
            var errors = new []
            {
                new ValidationResult(""),
            };

            // When
            var result = new CommandValidationResult(false, errors);

            // Then
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.NotOk, Is.True);
            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void Should_create_result_without_errors()
        {
            // When
            var result = new CommandValidationResult(true, null);

            // Then
            Assert.That(result.Errors, Is.Not.Null);
            Assert.That(result.Errors, Is.Empty);
            Assert.That(result.Ok, Is.True);
            Assert.That(result.NotOk, Is.False);
        }
    }
}
