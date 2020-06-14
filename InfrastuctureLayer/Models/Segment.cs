using System;
using System.Collections.Generic;

namespace InfrastuctureLayer.Models
{
    public class Segment
    {
        public string OperatingSupplier { get; set; }

        public string MarketingSupplier { get; set; }

        public override string ToString()
        {
            return $"\nSegment:\noperating_supplier -> {OperatingSupplier};\nmarketing_supplier -> {MarketingSupplier}";
        }

        protected bool Equals(Segment other)
        {
            return OperatingSupplier == other.OperatingSupplier && MarketingSupplier == other.MarketingSupplier;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Segment) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OperatingSupplier, MarketingSupplier);
        }
    }
}