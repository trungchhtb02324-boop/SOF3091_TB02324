using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SOF3091.Automation.Core;

namespace SOF3091.Automation.Tests;

public abstract class BaseTest
{
    protected IWebDriver Driver = null!;
    protected AutomationConfig Config = null!;

    [SetUp]
    public void SetUp()
    {
        Config = AutomationConfig.Load();
        Driver = DriverFactory.Create(Config);
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            if (Driver is not null && TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                SaveFailureScreenshot();
            }
        }
        finally
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }

    private void SaveFailureScreenshot()
    {
        if (Driver is not ITakesScreenshot screenshotDriver) return;

        try
        {
            var directory = Path.Combine(TestContext.CurrentContext.WorkDirectory, "TestResults", "Screenshots");
            Directory.CreateDirectory(directory);
            var safeName = string.Concat(TestContext.CurrentContext.Test.Name
                .Select(character => Path.GetInvalidFileNameChars().Contains(character) ? '_' : character));
            var filePath = Path.Combine(directory, $"{safeName}_{DateTime.UtcNow:yyyyMMdd_HHmmss}.png");
            screenshotDriver.GetScreenshot().SaveAsFile(filePath);
            TestContext.Progress.WriteLine($"Failure screenshot: {filePath}");
        }
        catch (WebDriverException exception)
        {
            TestContext.Progress.WriteLine($"Could not capture failure screenshot: {exception.Message}");
        }
    }
}
