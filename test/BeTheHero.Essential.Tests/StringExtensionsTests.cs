using NUnit.Framework;

namespace BeTheHero.Essential.Tests
{
    public class StringExtensionsTests
    {
        [Test]
        public void IsEmpty_should_return_true_if_string_is_empty()
        {
            const string value = "  ";

            var result = value.IsEmpty();

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsNotEmpty_should_return_true_if_string_is_not_empty()
        {
            const string value = "test";

            var result = value.IsNotEmpty();

            Assert.That(result, Is.True);
        }
    }
}
