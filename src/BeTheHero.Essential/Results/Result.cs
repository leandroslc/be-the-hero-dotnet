namespace BeTheHero.Essential.Results
{
    public abstract class Result
    {
        public Result(bool ok)
        {
            Ok = ok;
        }

        public bool Ok { get; }

        public bool NotOk => !Ok;
    }
}
