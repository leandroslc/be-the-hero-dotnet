using BeTheHero.Essential;

namespace BeTheHero.Organizations
{
    public sealed class City
    {
        private string name;
        private string state;

        public City(string name, string state)
        {
            Name = name;
            State = state;
        }

        public string Name
        {
            get => name;
            set => name = Check.GetRequired(value, nameof(Name));
        }

        public string State
        {
            get => state;
            set => state = Check.GetRequired(value, nameof(State));
        }
    }
}
