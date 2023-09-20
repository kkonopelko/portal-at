using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenQA.Selenium;
using Portal.Automation.Web.Configuration;
using Portal.Automation.Web.Drivers;

namespace Portal.Automation.Tests.Configuration
{
    public static class DependencyRegistrator
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddTransient(typeof(IWebDriver), serviceProvider => serviceProvider.GetRequiredService<DriverFactory>().GetDriver(TestContext.CurrentContext.Test.ID))
                .RegisterWebDependencies(configuration);
        }
    }
}
