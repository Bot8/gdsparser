using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using InfrastuctureLayer.GdsModels;
using InfrastuctureLayer.Models;

namespace InfrastuctureLayer.Gds.Sirena
{
    public class Driver
    {
        private readonly IMapper _mapper;

        public Driver()
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

            _mapper = config.CreateMapper();
        }

        public List<TripModel> Trips()
        {
            var response = @"
                <Trips>
                  <Trip>
                    <Supplier>SU</Supplier>
                    <Fligth>10</Fligth>
                  </Trip>
                  <Trip>
                    <Supplier>S7</Supplier>
                    <Fligth>11</Fligth>
                  </Trip>
                  <Trip>
                    <Supplier>N4</Supplier>
                    <Fligth>15</Fligth>
                  </Trip>
                  <Trip>
                    <Supplier>XX</Supplier>
                    <Fligth>20</Fligth>
                    <variants>
                      <variant>
                        <segment operating_supplier='SU' marketing_supplier='S7'></segment>
                        <segment operating_supplier='SU' marketing_supplier='S7'></segment>
                      </variant>
                      <variant>
                        <segment operating_supplier='AA' marketing_supplier='BB'></segment>
                        <segment operating_supplier='AA' marketing_supplier='BB'></segment>
                      </variant>
                    </variants>
                  </Trip>
                </Trips>
            ";
            var serializer = new XmlSerializer(typeof(TripsResponseModel.Trips));
            var rawTrips = (TripsResponseModel.Trips) serializer.Deserialize(new StringReader(response));
            var trips = new List<TripModel>();
            foreach (var rawTrip in rawTrips.Trip)
            {
                trips.Add(_mapper.Map<TripModel>(rawTrip));
            }

            return trips;
        }

        public string TripFareRules()
        {
            var response = @"
                <fareremark>
                  <remark new_fare='true'>some text 1</remark>
                  <remark new_fare='true'>some text 2</remark>
                  <remark new_fare='true'>some text 3</remark>
                  <remark new_fare='true'>some text 4</remark>
                </fareremark>
            ";
            var serializer = new XmlSerializer(typeof(FareRemarkResponseModel.Fareremark));
            var rawFareRemark =
                (FareRemarkResponseModel.Fareremark) serializer.Deserialize(new StringReader(response));

             var fareremark = _mapper.Map<Fareremark>(rawFareRemark);

             return fareremark.Remarks.Aggregate("", (current, remark) => current + remark + " ");
        }
    }
}