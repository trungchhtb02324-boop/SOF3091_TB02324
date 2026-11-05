using OpenQA.Selenium;

namespace SOF3091.Automation.Pages;

public sealed class CheckoutPage : BasePage
{
    private static readonly By FirstName = By.Id("first-name");
    private static readonly By LastName = By.Id("last-name");
    private static readonly By PostalCode = By.Id("postal-code");
    private static readonly By ContinueButton = By.Id("continue");
    private static readonly By FinishButton = By.Id("finish");
    private static readonly By CompleteHeader = By.ClassName("complete-header");
    private static readonly By ErrorMessage = By.CssSelector("[data-test='error']");

    public CheckoutPage(IWebDriver driver, int waitSeconds = 10) : base(driver, waitSeconds) { }

    public void EnterCustomerInformation(string firstName, string lastName, string postalCode)
    {
        Type(FirstName, firstName);
        Type(LastName, lastName);
        Type(PostalCode, postalCode);
    }

    public void ContinueToOverview() => Click(ContinueButton);

    public void FinishOrder() => Click(FinishButton);

    public string ConfirmationMessage => TextOf(CompleteHeader);

    public string GetErrorMessage() => TextOf(ErrorMessage);
}
