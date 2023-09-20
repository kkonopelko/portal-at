using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Portal.Automation.Tests.Configuration
{
    public static class ServiceProviderFactory
    {
        public static IServiceProvider GetServiceProvider(
            Func<IServiceCollection, IConfiguration, IServiceCollection> serviceRegistrationFunc = null,
            Func<IConfigurationBuilder, IConfigurationBuilder> extendConfigurationFunc = null)
        {
            var configuration = CreateConfiguration(extendConfigurationFunc);
            IServiceCollection services = new ServiceCollection();

            if (serviceRegistrationFunc != null)
            {
                services = serviceRegistrationFunc(services, configuration);
            }

            return services.BuildServiceProvider();
        }

        private static IConfiguration CreateConfiguration(Func<IConfigurationBuilder, IConfigurationBuilder> extendConfigurationFunc)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables();

            if (!(extendConfigurationFunc is null))
            {
                configurationBuilder = extendConfigurationFunc(configurationBuilder);
            }

            return configurationBuilder.Build();
        }
    }
}
