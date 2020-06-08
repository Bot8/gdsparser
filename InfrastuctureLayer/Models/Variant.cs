using System.Collections.Generic;
using System.Linq;

namespace InfrastuctureLayer.Models
{
    public class Variant
    {
        public List<Segment> Segments;
        
        public override string ToString()
        {
            var result = "";
            
            return Segments.Aggregate(result, (current, variant) => current + $"{variant}\n");
        }
    }
}
