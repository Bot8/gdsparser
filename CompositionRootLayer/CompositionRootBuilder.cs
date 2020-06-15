using InfrastuctureLayer;
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
            serviceCollection.AddTransient<InfrastuctureLayer.Gds.Sirena.Client>();
            serviceCollection.AddTransient<InfrastuctureLayer.Gds.Sirena.Driver>();
            serviceCollection.AddTransient<InfrastuctureLayer.Gds.Ctrip.Client>();
            serviceCollection.AddTransient<InfrastuctureLayer.Gds.Ctrip.Driver>();
        }
    }
}