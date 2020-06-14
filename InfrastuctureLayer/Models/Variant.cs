using System.Collections.Generic;
using System.Linq;

namespace InfrastuctureLayer.Models
{
    public class Variant
    {
        public List<Segment> Segments;

        public override string ToString()
        {
            return Segments.Aggregate("", (current, variant) => current + $"\nVariant: {variant}");
        }

        protected bool Equals(Variant other)
        {
            return Segments.SequenceEqual(other.Segments);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Variant) obj);
        }

        public override int GetHashCode()
        {
            return (Segments != null ? Segments.GetHashCode() : 0);
        }
    }
}