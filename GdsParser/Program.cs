using System;
using System.Text.Json;
using InfrastuctureLayer.Gds.Sirena;

namespace GdsParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var trips = new Driver().Trips();
            var fareRemark = new Driver().TripFareRules();

            foreach (var trip in trips)
            {
                Console.WriteLine($"{trip}");
            }

            Console.WriteLine($"{fareRemark}");

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            Console.WriteLine(JsonSerializer.Serialize(trips, options));
            Console.WriteLine(JsonSerializer.Serialize(fareRemark, options));
        }
    }
}