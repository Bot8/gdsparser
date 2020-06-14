using System;
using InfrastuctureLayer.Gds.Sirena;
using Newtonsoft.Json;

namespace GdsParser
{
    class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = CompositionRootLayer.CompositionRootBuilder.BuildServiceProvider();
            var driver = (Driver)serviceProvider.GetService(typeof(Driver));
            
            var trips = driver.Trips();
            var fareRemark = driver.TripFareRules();

            Console.WriteLine(JsonConvert.SerializeObject(trips, Formatting.Indented));
            Console.WriteLine(JsonConvert.SerializeObject(fareRemark, Formatting.Indented));
        }
    }
}