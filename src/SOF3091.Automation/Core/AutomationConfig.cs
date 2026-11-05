using Microsoft.Extensions.Configuration;

namespace SOF3091.Automation.Core;

/// <summary>
/// Strongly typed settings for the browser automation framework.
/// Environment variables using the Automation__ prefix override appsettings.json.
/// </summary>
public sealed class AutomationConfig
{
    public string BaseUrl { get; init; } = "https://www.saucedemo.com/";
    public string Browser { get; init; } = "chrome";
    public bool Headless { get; init; }
    public int ExplicitWaitSeconds { get; init; } = 10;
    public int PageLoadTimeoutSeconds { get; init; } = 30;

    public static AutomationConfig Load()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddEnvironmentVariables()
            .Build();

        return configuration.GetSection("Automation").Get<AutomationConfig>()
               ?? new AutomationConfig();
    }
}
