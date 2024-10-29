using Microsoft.Extensions.DependencyInjection;
using IPage = Portal.Automation.Web.Domain.Pages.IPage;
using IPwPage = Microsoft.Playwright.IPage;

namespace Portal.Automation.Web.Playwright2.Pages
{
    internal class BasePage(PageFactory pageFactory, IServiceProvider serviceProvider)
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        protected IPwPage Page { get; } = pageFactory.GetPage();

        protected T GetPage<T>()
            where T : IPage
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
