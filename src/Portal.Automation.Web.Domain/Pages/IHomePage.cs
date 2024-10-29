namespace Portal.Automation.Web.Domain.Pages;

public interface IHomePage : IPage
{
    public Task<bool> IsShpingCartDisplayed();
}
