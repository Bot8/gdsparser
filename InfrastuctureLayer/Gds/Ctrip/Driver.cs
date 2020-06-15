using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InfrastuctureLayer.Gds.Ctrip.Models;
using Newtonsoft.Json;
using InfrastuctureLayer.Models;

namespace InfrastuctureLayer.Gds.Ctrip
{
    public class Driver : IDriver
    {
        private readonly Client _client;
        private readonly IMapper _mapper;

        public Driver(Client client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public List<TripModel> Trips()
        {
            var response = _client.Request(RequestName.Flights);
            var rawFlights = JsonConvert.DeserializeObject<FlightsResponseModel>(response);

            return rawFlights.Flights.Select(rawFlight => _mapper.Map<TripModel>(rawFlight)).ToList();
        }

        public string TripFareRules()
        {
            var response = _client.Request(RequestName.FareConditions);
            var rawFareConditions = JsonConvert.DeserializeObject<FareConditionsResponseModel>(response);

            var fareremark = _mapper.Map<Fareremark>(rawFareConditions);

            return fareremark.Remarks.Aggregate("", (current, remark) => current + remark + " ");
        }
    }
}