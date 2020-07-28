using System;
using BeTheHero.Core.Organizations;
using BeTheHero.Essential;

namespace BeTheHero.Core.Incidents
{
    public sealed class Incident
    {
        private string title;
        private string description;
        private decimal value;

        public Incident(
            string title,
            string description,
            decimal value,
            Organization organization)
        {
            Title = title;
            Description = description;
            Value = value;
            Organization = organization ?? throw new ArgumentNullException(nameof(organization));
            OrganizationId = organization.Id;
        }

        private Incident()
        {
        }

        public long Id { get; private set; }

        public string Title
        {
            get => title;
            set => title = Check.GetRequired(value, nameof(Title));
        }

        public string Description
        {
            get => description;
            set => description = Check.GetRequired(value, nameof(Description));
        }

        public decimal Value
        {
            get => value;
            set => this.value = Check.GetIf(value, Check.GreaterThan, 0, nameof(Value));
        }

        public Organization Organization { get; private set; }

        public string OrganizationId { get; private set; }
    }
}
