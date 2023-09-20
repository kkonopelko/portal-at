namespace Portal.Automation.Web.Drivers.DriverOptions
{
    using OpenQA.Selenium;

    public interface IDriverOptions<out T> where T : DriverOptions
    {
        T GetDriverOptionsForRegularRun(string downloadDirectory);
        T GetDriverOptionsForHeadlessRun(string downloadDirectory);
    }
}
