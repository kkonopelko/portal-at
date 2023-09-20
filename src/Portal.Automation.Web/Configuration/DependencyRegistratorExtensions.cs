using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Portal.Automation.Web.Drivers;
using Portal.Automation.Web.Drivers.Models.Settings;
using Portal.Automation.Web.PageObjects;
using Portal.Automation.Web.Utils;

namespace Portal.Automation.Web.Configuration
{
    public static class DependencyRegistratorExtensions
    {
        public static IServiceCollection RegisterWebDependencies(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddConfiguration(configuration)
                .AddSingleton<DriverFactory>()
                .AddPages();

        private static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration) =>
            services.AddSingleton(configuration.GetSection(nameof(DriverSettings)).Get<DriverSettings>()!)
            .AddSingleton(configuration.GetSection(nameof(UiSettings)).Get<UiSettings>()!);

        private static IServiceCollection AddPages(this IServiceCollection services) =>
            services
                .AddTransient(serviceProvider =>
                    new Navigation(
                serviceProvider.GetRequiredService<IWebDriver>(),
                        serviceProvider.GetRequiredService<UiSettings>().BaseUrl))
                .AddTransient<LoginPage>()
                .AddTransient<HomePage>();
    }
}
