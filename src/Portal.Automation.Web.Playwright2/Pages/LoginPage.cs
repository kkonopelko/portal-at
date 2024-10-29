using Portal.Automation.Web.Domain.Pages;

namespace Portal.Automation.Web.Playwright2.Pages;

internal class LoginPage : BasePage, ILoginPage
{
    public LoginPage(
        PageFactory pageFactory,
        IServiceProvider serviceProvider)
        : base(pageFactory, serviceProvider)
    {
    }

    public async Task<ILoginPage> TypeUsernameAsync(string userName)
    {
        await Page.FillAsync("id=user-name", userName);
        return this;
    }

    public async Task<ILoginPage> TypePasswordAsync(string password)
    {
        await Page.FillAsync("id=password", password);
        return this;
    }

    public async Task<IHomePage> ClickLoginButtonAsync()
    {
        await Page.ClickAsync("id=login-button");
        return GetPage<IHomePage>();
    }
}
