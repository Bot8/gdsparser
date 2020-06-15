using System.Collections.Generic;
using Newtonsoft.Json;

namespace InfrastuctureLayer.Gds.Ctrip.Models
{
    public class FareConditionsResponseModel
    {
        [JsonProperty("fare_conditions")] 
        public List<string> FareConditions;
    }
}