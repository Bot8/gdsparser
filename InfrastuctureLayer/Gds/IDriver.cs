using System.Collections.Generic;
using InfrastuctureLayer.Models;

namespace InfrastuctureLayer.Gds
{
    public interface IDriver
    {
        public List<TripModel> Trips();
        public string TripFareRules();
    }
}