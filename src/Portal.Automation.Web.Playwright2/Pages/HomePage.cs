using Portal.Automation.Web.Domain.Pages;

namespace Portal.Automation.Web.Playwright2.Pages;

internal class HomePage : BasePage, IHomePage
{
    public HomePage(PageFactory pageFactory, IServiceProvider serviceProvider)
        : base(pageFactory, serviceProvider)
    {
    }

    public async Task<bool> IsShpingCartDisplayed()
    {
        return await Page.GetByTestId("shopping_cart_container").IsVisibleAsync();
    }
}
