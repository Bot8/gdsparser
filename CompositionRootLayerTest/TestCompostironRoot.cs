using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace CompositionRootLayerTest
{
    public class Tests
    {
        [Test]
        public void TestCompositionRootBuild()
        {
            var serviceCollection = new ServiceCollection();
            var serviceProvider = CompositionRootLayer.CompositionRootBuilder.BuildServiceProvider();
            
            CompositionRootLayer.CompositionRootBuilder.BindServices(serviceCollection);

            foreach (var serviceDescriptor in serviceCollection)
            {
                Assert.NotNull(serviceProvider.GetService(serviceDescriptor.ServiceType));
            }
        }
    }
}