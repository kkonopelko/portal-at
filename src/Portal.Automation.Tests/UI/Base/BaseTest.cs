using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Portal.Automation.Web.Drivers;
using Portal.Automation.Web.Drivers.Models.Settings;
using System.IO;

[assembly: LevelOfParallelism(2)]
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace Portal.Automation.Tests.UI.Base
{
    [TestFixture]
    public class BaseTest
    {
        private DriverFactory _driverFactory;

        protected UiSettings UiSettings { get; private set; }

        protected string DownloadDirectoryPath { get; private set; }

        [OneTimeSetUp]
        public void BeforeEachTestFixture()
        {
            _driverFactory = GetService<DriverFactory>();
            UiSettings = GetService<UiSettings>();

            DownloadDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Downloads");
        }

        [TearDown]
        public void AfterEachTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                // testUtils.TakeScreenshot();
            }

            _driverFactory.ShutDownDriver(TestContext.CurrentContext.Test.ID);
        }

        protected T GetService<T>() => SetUp.ServiceProvider.GetRequiredService<T>();
    }
}
