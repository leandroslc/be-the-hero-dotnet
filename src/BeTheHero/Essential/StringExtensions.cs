namespace BeTheHero.Essential
{
    public static class StringExtensions
    {
        public static bool IsNotEmpty(this string value)
            => !IsEmpty(value);

        public static bool IsEmpty(this string value)
            => string.IsNullOrWhiteSpace(value);
    }
}
