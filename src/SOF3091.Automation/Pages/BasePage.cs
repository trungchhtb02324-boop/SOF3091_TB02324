using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SOF3091.Automation.Pages;

/// <summary>Common explicit-wait and interaction helpers shared by all page objects.</summary>
public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    private readonly WebDriverWait _wait;

    protected BasePage(IWebDriver driver, int waitSeconds = 10)
    {
        Driver = driver ?? throw new ArgumentNullException(nameof(driver));
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
    }

    protected IWebElement WaitVisible(By locator) =>
        _wait.Until(driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                return element.Displayed ? element : null;
            }
            catch (NoSuchElementException) { return null; }
            catch (StaleElementReferenceException) { return null; }
        })!;

    protected IWebElement WaitClickable(By locator) =>
        _wait.Until(driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                return element.Displayed && element.Enabled ? element : null;
            }
            catch (NoSuchElementException) { return null; }
            catch (StaleElementReferenceException) { return null; }
        })!;

    protected bool WaitUntil(Func<IWebDriver, bool> condition) => _wait.Until(condition);

    protected void Click(By locator) => WaitClickable(locator).Click();

    protected void Type(By locator, string value)
    {
        var element = WaitVisible(locator);
        element.Clear();
        element.SendKeys(value);
    }

    protected string TextOf(By locator) => WaitVisible(locator).Text;
}
