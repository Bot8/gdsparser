using CompositionRootLayer.Factory;
using InfrastuctureLayer;
using InfrastuctureLayer.Gds;
using InfrastuctureLayer.Gds.Sirena;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRootLayer
{
    public class CompositionRootBuilder
    {
        public static ServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            BindServices(serviceCollection);
            return serviceCollection.BuildServiceProvider();
        }

        public static void BindServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<Logger>();
            serviceCollection.AddTransient<Client>();
            serviceCollection.AddTransient<Driver>();
            serviceCollection.AddTransient<InfrastuctureLayer.Gds.Ctrip.Client>();
            serviceCollection.AddTransient<InfrastuctureLayer.Gds.Ctrip.Driver>();
            serviceCollection.AddTransient(c => AutoMapperFactory.Create());
            serviceCollection.AddTransient<GdsFactory>();
        }
    }
}