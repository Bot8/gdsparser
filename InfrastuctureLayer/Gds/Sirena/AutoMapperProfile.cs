using AutoMapper;
using InfrastuctureLayer.Gds.Sirena.Models;
using InfrastuctureLayer.Models;

namespace InfrastuctureLayer.Gds.Sirena
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TripsResponseModel.Segment, Segment>();
            CreateMap<TripsResponseModel.Variant, Variant>();
            CreateMap<TripsResponseModel.Trip, TripModel>()
                .ForMember(
                    d => d.Variants,
                    opt => opt.MapFrom(src => src.Variants.Variant)
                );
            CreateMap<FareRemarkResponseModel.Remark, Remark>()
                .ForMember(
                    d => d.IsNewFare,
                    opt => opt.MapFrom(src => src.NewFare == "true")
                )
                .ForMember(
                    d => d.Value,
                    opt => opt.MapFrom(src => src.Text)
                );

            CreateMap<FareRemarkResponseModel.Fareremark, Fareremark>()
                .ForMember(
                    d => d.Remarks,
                    opt => opt.MapFrom(src => src.Remark)
                );
        }
    }
}