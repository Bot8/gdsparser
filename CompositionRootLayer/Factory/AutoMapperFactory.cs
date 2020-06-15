using AutoMapper;

namespace CompositionRootLayer.Factory
{
    public static class AutoMapperFactory
    {
        public static IMapper Create()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InfrastuctureLayer.Gds.Ctrip.AutoMapperProfile>();
                cfg.AddProfile<InfrastuctureLayer.Gds.Sirena.AutoMapperProfile>();
            });

            return config.CreateMapper();
        }
    }
}