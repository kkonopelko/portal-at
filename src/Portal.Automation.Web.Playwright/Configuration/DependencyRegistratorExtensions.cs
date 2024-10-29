using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portal.Automation.Web.Playwright1.Factories;
using Portal.Automation.Web.Playwright1.Interfaces.PageObjects;
using Portal.Automation.Web.Playwright1.PageObjects;

namespace Portal.Automation.Web.Playwright1.Configuration
{
    public static class DependencyRegistratorExtensions
    {
        public static IServiceCollection RegisterWebDependencies(this IServiceCollection services) =>
            services
                // .AddConfiguration(configuration)
                .AddPages();

        // TODO: ADD config with base url, browser settings options - mode, browser, size?
        //private static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration) =>
        //    services
        //        .AddSingleton(configuration.GetSection(nameof(UiSettings)).Get<UiSettings>());

        private static IServiceCollection AddPages(this IServiceCollection services) =>
            services
                .AddSingleton<BrowserFactory>()
                .AddSingleton<PageFactory>()
                .AddTransient<ILoginPage, LoginPage>()
                .AddTransient<IHomePage, HomePage>();
    }
}
