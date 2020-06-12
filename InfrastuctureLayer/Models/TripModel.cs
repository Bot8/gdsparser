using System;
using System.Collections.Generic;
using System.Linq;

namespace InfrastuctureLayer.Models
{
    public class TripModel
    {
        public string Supplier { get; set; }
        public string Fligth { get; set; }

        public List<Variant> Variants;

        public override string ToString()
        {
            var result = $"Trip: {Supplier} --> {Fligth}\n";
            return Variants.Aggregate(result, (current, variant) => current + $"\n{variant}");
        }

        protected bool Equals(TripModel other)
        {
            return Equals(Variants, other.Variants) && Supplier == other.Supplier && Fligth == other.Fligth;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TripModel) obj);
        }
    }
}