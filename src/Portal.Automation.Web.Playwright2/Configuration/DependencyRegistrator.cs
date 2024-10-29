using Microsoft.Extensions.DependencyInjection;
using Portal.Automation.Web.Domain;
using Portal.Automation.Web.Domain.Pages;
using Portal.Automation.Web.Playwright2.Pages;

namespace Portal.Automation.Web.Playwright2.Configuration;

public static class DependencyRegistrator
{
    public static IServiceCollection RegisterPwDependencies(this IServiceCollection services)
    {
        services.AddScoped<PageFactory>();
        services.AddScoped<IBrowser, PwBrowser>();

        services.RegisterPages();

        return services;
    }

    private static IServiceCollection RegisterPages(this IServiceCollection services)
    {
        services.AddScoped<ILoginPage, LoginPage>();
        services.AddScoped<IHomePage, HomePage>();

        return services;
    }
}
