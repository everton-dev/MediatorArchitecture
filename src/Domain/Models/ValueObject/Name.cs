using System.Collections.Generic;

namespace Domain.Models.ValueObject
{
    public record Name : ValueObject
    {
        public string InitialName { get; init; }
        public string MiddleName { get; init; }
        public string LastName { get; init; }

        public Name(string initialName, string middleName, string lastName)
        {
            InitialName = initialName;
            MiddleName = middleName;
            LastName = lastName;
        }

        protected override IEnumerable<object> GetEqualityComponets()
        {
            yield return InitialName;
            yield return MiddleName;
            yield return LastName;
        }
    }
}