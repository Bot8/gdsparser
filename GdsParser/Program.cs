using System;
using InfrastuctureLayer.Gds.Sirena;
using Newtonsoft.Json;

namespace GdsParser
{
    class Program
    {
        public static void Main(string[] args)
        {
            var trips = new Driver().Trips();
            var fareRemark = new Driver().TripFareRules();

            Console.WriteLine(JsonConvert.SerializeObject(trips, Formatting.Indented));
            Console.WriteLine(JsonConvert.SerializeObject(fareRemark, Formatting.Indented));
        }
    }
}