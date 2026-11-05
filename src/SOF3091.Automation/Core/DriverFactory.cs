using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SOF3091.Automation.Core;

/// <summary>Creates browser instances in a single, configurable location.</summary>
public static class DriverFactory
{
    public static IWebDriver Create(AutomationConfig config)
    {
        ArgumentNullException.ThrowIfNull(config);

        if (!string.Equals(config.Browser, "chrome", StringComparison.OrdinalIgnoreCase))
        {
            throw new NotSupportedException(
                $"Browser '{config.Browser}' is not supported. Configure Browser=chrome.");
        }

        var options = new ChromeOptions();
        options.AddArgument("--window-size=1440,1000");
        options.AddArgument("--disable-notifications");
        options.AddArgument("--disable-popup-blocking");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");

        if (config.Headless)
        {
            options.AddArgument("--headless=new");
        }

        // Selenium Manager resolves the matching ChromeDriver automatically.
        var driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(config.PageLoadTimeoutSeconds);
        return driver;
    }
}
