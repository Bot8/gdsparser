using System;

namespace InfrastuctureLayer.Gds
{
    public class GdsFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public GdsFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IDriver GetGdsDriver(GdsEnum gds)
        {
            switch (gds)
            {
                case GdsEnum.Sirena:
                    return (Sirena.Driver) _serviceProvider.GetService(typeof(Sirena.Driver));
                case GdsEnum.Ctrip:
                    return (Ctrip.Driver) _serviceProvider.GetService(typeof(Ctrip.Driver));
            }

            throw new NotImplementedException($"Driver for gds {gds} is not implemented yet");
        }
    }
}