using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using InfrastuctureLayer.Gds.Sirena.Models;
using InfrastuctureLayer.Models;

namespace InfrastuctureLayer.Gds.Sirena
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
            var response = _client.Request(RequestName.Trips);
            var serializer = new XmlSerializer(typeof(TripsResponseModel.Trips));
            var rawTrips = (TripsResponseModel.Trips) serializer.Deserialize(new StringReader(response));

            return rawTrips.Trip.Select(rawTrip => _mapper.Map<TripModel>(rawTrip)).ToList();
        }

        public string TripFareRules()
        {
            var response = _client.Request(RequestName.FareRules);
            var serializer = new XmlSerializer(typeof(FareRemarkResponseModel.Fareremark));
            var rawFareRemark =
                (FareRemarkResponseModel.Fareremark) serializer.Deserialize(new StringReader(response));

            var fareremark = _mapper.Map<Fareremark>(rawFareRemark);

            return fareremark.Remarks.Aggregate("", (current, remark) => current + remark + " ");
        }
    }
}