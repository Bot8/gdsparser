using InfrastuctureLayer;
using InfrastuctureLayer.Gds.Sirena;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRootLayer
{
    public class CompositionRootBuilder
    {
        public static ServiceProvider Build()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<Logger>();
            serviceCollection.AddTransient<Client>();
            serviceCollection.AddTransient<Driver>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}