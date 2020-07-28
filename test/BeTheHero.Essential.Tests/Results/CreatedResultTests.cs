using NUnit.Framework;

namespace BeTheHero.Essential.Results.Tests
{
    public class CreatedResultTests
    {
        [Test]
        public void Should_create_created_result_with_value()
        {
            // Given
            var value = new { Name = "Test" };

            // When
            var result = new CreatedResult(value);

            // Then
            Assert.That(result.Ok, Is.True);
            Assert.That(result.NotOk, Is.False);
            Assert.That(result.Value, Is.SameAs(value));
        }
    }
}
