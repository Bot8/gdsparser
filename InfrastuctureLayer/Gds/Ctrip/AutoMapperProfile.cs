using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InfrastuctureLayer.Gds.Ctrip.Models;
using InfrastuctureLayer.Models;

namespace InfrastuctureLayer.Gds.Ctrip
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FlightsResponseModel.Segment, Segment>();
            CreateMap<FlightsResponseModel.Flight, TripModel>().ConvertUsing<FlightTypeConverter>();
            CreateMap<FareConditionsResponseModel, Fareremark>().ForMember(
                d => d.Remarks,
                opt => opt.MapFrom(src => src.FareConditions)
            );
            CreateMap<string, Remark>().ConvertUsing<RemarkTypeConverter>();
        }
    }

    public class FlightTypeConverter : ITypeConverter<FlightsResponseModel.Flight, TripModel>
    {
        public TripModel Convert(FlightsResponseModel.Flight source, TripModel destination, ResolutionContext context)
        {
            var variants = new List<Variant>();

            variants.Add(new Variant
            {
                Segments = source.Segments.Select(segment => context.Mapper.Map<Segment>(segment)).ToList()
            });

            return new TripModel {Variants = variants};
        }
    }   
    
    public class RemarkTypeConverter : ITypeConverter<string, Remark>
    {
        public Remark Convert(string source, Remark destination, ResolutionContext context)
        {
            return new Remark {Value = source};
        }
    }
}