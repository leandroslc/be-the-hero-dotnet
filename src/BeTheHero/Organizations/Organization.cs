using System;
using BeTheHero.Essential;

namespace BeTheHero.Organizations
{
    public sealed class Organization
    {
        private string name;
        private string email;
        private string phone;

        public Organization(
            string name,
            string email,
            string phone,
            City city)
            : this()
        {
            Name = name;
            Email = email;
            Phone = phone;
            City = city ?? throw new ArgumentNullException(nameof(city));
        }

        private Organization()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }

        public string Name
        {
            get => name;
            set => name = Check.GetRequired(value, nameof(Name));
        }

        public string Email
        {
            get => email;
            set => email = Check.GetRequired(value, nameof(Email));
        }

        public string Phone
        {
            get => phone;
            set => phone = Check.GetRequired(value, nameof(Phone));
        }

        public City City { get; private set; }
    }
}
