using FluentAssertions;
using NUnit.Framework;
using Portal.Automation.Tests.Configuration;
using System;

namespace Portal.Automation.Tests.UI
{
    [SetUpFixture]
    public class SetUp
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [OneTimeSetUp]
        public void SetUpBeforeAllTests()
        {
            ServiceProvider = ServiceProviderFactory.GetServiceProvider(DependencyRegistrator.Register);

            ConfigureAssertionOptions();
        }

        [OneTimeTearDown]
        public void RunAfterAllTests()
        {
            if (!(ServiceProvider is null))
            {
                ((IDisposable)ServiceProvider).Dispose();
            }
        }

        private void ConfigureAssertionOptions()
        {
            AssertionOptions.AssertEquivalencyUsing(options =>
                options
                    .Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation, TimeSpan.FromSeconds(1)))
                    .WhenTypeIs<DateTime>());
        }
    }
}
