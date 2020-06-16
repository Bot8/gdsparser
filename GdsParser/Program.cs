using System;
using InfrastuctureLayer.Gds;
using Newtonsoft.Json;

namespace GdsParser
{
    class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = CompositionRootLayer.CompositionRootBuilder.BuildServiceProvider();
            var gdsFactory = (GdsFactory)serviceProvider.GetService(typeof(GdsFactory));
            var driver = gdsFactory.GetGdsDriver(GdsEnum.Ctrip);
            
            var trips = driver.Trips();
            var fareRemark = driver.TripFareRules();

            Console.WriteLine(JsonConvert.SerializeObject(trips, Formatting.Indented));
            Console.WriteLine(JsonConvert.SerializeObject(fareRemark, Formatting.Indented));
        }
    }
}