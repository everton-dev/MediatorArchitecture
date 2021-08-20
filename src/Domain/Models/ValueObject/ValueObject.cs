using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models.ValueObject
{
    public abstract record ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
                return false;

            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right) => 
            !(EqualOperator(left, right));

        protected abstract IEnumerable<object> GetEqualityComponets();

        //public override bool Equals(object obj)
        //{
        //    if (obj == null || obj.GetType() != GetType())
        //        return false;

        //    var other = (ValueObject)obj;

        //    return this.GetEqualityComponets().SequenceEqual(other.GetEqualityComponets());
        //}

        public override int GetHashCode()
        {
            return GetEqualityComponets()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}