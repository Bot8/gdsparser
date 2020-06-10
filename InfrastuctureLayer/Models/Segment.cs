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

        public override bool Equals(object? obj)
        {
            if (null == obj)
            {
                return false;
            }

            var segment = (Segment) obj;

            if (OperatingSupplier != segment.OperatingSupplier)
            {
                return false;
            }

            if (MarketingSupplier != segment.MarketingSupplier)
            {
                return false;
            }

            return true;
        }
    }
}