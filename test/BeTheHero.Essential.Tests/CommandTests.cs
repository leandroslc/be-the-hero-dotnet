using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;

namespace BeTheHero.Essential.Tests
{
    public class CommandTests
    {
        [Test]
        public void IsValid_should_return_that_command_is_valid()
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
        public void IsValid_should_return_that_command_is_invalid()
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

        private class TestCommand : Command
        {
            [Required]
            public string Name { get; set; }

            [EmailAddress]
            public string Email { get; set; }
        }
    }
}
