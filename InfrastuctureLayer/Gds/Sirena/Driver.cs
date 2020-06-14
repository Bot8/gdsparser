using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using InfrastuctureLayer.GdsModels;
using InfrastuctureLayer.Models;

namespace InfrastuctureLayer.Gds.Sirena
{
    public class Driver: IDriver
    {
        private readonly Client _client;
        private readonly IMapper _mapper;

        public Driver(Client client)
        {
            _client = client;
            _mapper = CreateMapper();
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

        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TripsResponseModel.Segment, Segment>();
                cfg.CreateMap<TripsResponseModel.Variant, Variant>();
                cfg.CreateMap<TripsResponseModel.Trip, TripModel>()
                    .ForMember(
                        d => d.Variants,
                        opt => opt.MapFrom(src => src.Variants.Variant)
                    );
                cfg.CreateMap<FareRemarkResponseModel.Remark, Remark>()
                    .ForMember(
                        d => d.IsNewFare,
                        opt => opt.MapFrom(src => src.NewFare == "true")
                    )
                    .ForMember(
                        d => d.Value,
                        opt => opt.MapFrom(src => src.Text)
                    );

                cfg.CreateMap<FareRemarkResponseModel.Fareremark, Fareremark>()
                    .ForMember(
                        d => d.Remarks,
                        opt => opt.MapFrom(src => src.Remark)
                    );
            });

            return config.CreateMapper();
        }
    }
}