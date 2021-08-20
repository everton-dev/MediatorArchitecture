using System.Collections.Generic;

namespace Domain.Models.ValueObject
{
    public record Address : ValueObject
    {
        public string Street { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        public string ZipCode { get; init; }
        
        public Address() { }

        public Address(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }

        protected override IEnumerable<object> GetEqualityComponets()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }
    }
}