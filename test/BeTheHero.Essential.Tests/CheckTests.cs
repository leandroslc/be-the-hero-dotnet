using NUnit.Framework;

namespace BeTheHero.Essential.Tests
{
    public class CheckTests
    {
        [Test]
        public void GetRequired_shold_fail_if_string_is_empty()
        {
            const string value = "  ";

            static void acao() => Check.GetRequired(value, nameof(value));

            var exception = Assert.Throws<InvalidArgumentException>(acao);

            Assert.That(exception.ParamName, Is.EqualTo("value"));
        }

        [Test]
        public void GetIf_should_fail_if_condition_evaluates_to_false()
        {
            const decimal value = 0;
            const decimal valueToCompare = 0;

            static void acao() => Check.GetIf(value, Check.GreaterThan, valueToCompare, nameof(value));

            var exception = Assert.Throws<InvalidArgumentException>(acao);

            Assert.That(exception.ParamName, Is.EqualTo("value"));
        }
    }
}
