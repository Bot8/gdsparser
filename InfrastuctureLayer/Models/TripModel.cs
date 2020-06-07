using System;

namespace InfrastuctureLayer.Models
{
    public class TripModel
    {
        public string Supplier { get; set; }
        public string Fligth { get; set; }

        public override string ToString()
        {
            return $"Trip: {Supplier} --> {Fligth}";
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