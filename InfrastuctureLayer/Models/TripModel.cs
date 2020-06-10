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

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            var trip = (TripModel) obj;

            if (trip.Fligth != Fligth)
            {
                return false;
            }

            if (trip.Supplier != Supplier)
            {
                return false;
            }

            return true;
        }
    }
}