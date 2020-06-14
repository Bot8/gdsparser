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

        public TripModel()
        {
            Variants = new List<Variant>();
        }

        public override string ToString()
        {
            var result = $"Trip: {Supplier} --> {Fligth}\n";
            return Variants.Aggregate(result, (current, variant) => current + $"\n{variant}");
        }

        protected bool Equals(TripModel other)
        {
            var variantsEquals = (0 == Variants.Count && 0 == other.Variants.Count) ||
                                 Variants.SequenceEqual(other.Variants);
            return variantsEquals && Supplier == other.Supplier && Fligth == other.Fligth;
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