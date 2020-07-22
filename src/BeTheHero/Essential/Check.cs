using System;

namespace BeTheHero.Essential
{
    public static class Check
    {
        public static string GetRequired(string value, string argumentName, string message = null)
        {
            return GetRequired(
                value,
                value.IsNotEmpty(),
                argumentName,
                message);
        }

        public static TValue GetIf<TValue>(
            TValue value,
            Func<TValue, TValue, bool> comparison,
            TValue expected,
            string argumentName,
            string message = null)
        {
            return comparison(value, expected) ? value : throw InvalidArgument(argumentName, message);
        }

        public static bool GreaterThan<TValue>(TValue value, TValue expected)
            where TValue : IComparable<TValue>
        {
            return value?.CompareTo(expected) > 0;
        }

        private static TValue GetRequired<TValue>(
            TValue value,
            bool hasValue,
            string argumentName,
            string message)
        {
            return hasValue ? value : throw InvalidArgument(argumentName, message);
        }

        private static InvalidArgumentException InvalidArgument(string argumentName, string message)
        {
            return message is null
                ? new InvalidArgumentException(argumentName)
                : new InvalidArgumentException(argumentName, message);
        }
    }
}
