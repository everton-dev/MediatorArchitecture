using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Models.ValueObject
{
    public record Document : ValueObject
    {
        public EnumTypeDocument TypeDocument { get; init; }
        public string Number { get; init; }

        public Document() { }

        public Document(EnumTypeDocument typeDocument, string number)
        {
            TypeDocument = typeDocument;
            Number = number;
        }

        protected override IEnumerable<object> GetEqualityComponets()
        {
            yield return TypeDocument;
            yield return Number;
        }
    }
}