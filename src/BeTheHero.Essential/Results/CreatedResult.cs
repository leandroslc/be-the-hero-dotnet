namespace BeTheHero.Essential.Results
{
    public sealed class CreatedResult : Result
    {
        public CreatedResult(object value = null)
            : base(true)
        {
            Value = value;
        }

        public object Value { get; }
    }
}
