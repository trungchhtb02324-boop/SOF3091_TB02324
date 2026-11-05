using OpenQA.Selenium;

namespace SOF3091.Automation.Pages;

public sealed class LoginPage : BasePage
{
    private static readonly By UsernameInput = By.Id("user-name");
    private static readonly By PasswordInput = By.Id("password");
    private static readonly By LoginButton = By.Id("login-button");
    private static readonly By ErrorMessage = By.CssSelector("[data-test='error']");

    public LoginPage(IWebDriver driver, int waitSeconds = 10) : base(driver, waitSeconds) { }

    public LoginPage Open(string baseUrl)
    {
        Driver.Navigate().GoToUrl(baseUrl);
        WaitVisible(UsernameInput);
        return this;
    }

    public void Login(string username, string password)
    {
        Type(UsernameInput, username);
        Type(PasswordInput, password);
        Click(LoginButton);
    }

    public string GetErrorMessage() => TextOf(ErrorMessage);
}
