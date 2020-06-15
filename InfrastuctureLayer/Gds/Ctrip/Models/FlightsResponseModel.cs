using System.Collections.Generic;
using Newtonsoft.Json;

namespace InfrastuctureLayer.Gds.Ctrip.Models
{
    public class FlightsResponseModel
    {
        [JsonProperty("flights")]
        public List<Flight> Flights;

        public class Flight
        {
            [JsonProperty("segments")]
            public List<Segment> Segments;
        }

        public class Segment
        {
            [JsonProperty("operating_supplier")] 
            public string OperatingSupplier { get; set; }

            [JsonProperty("marketing_supplier")] 
            public string MarketingSupplier { get; set; }
        }
    }
}