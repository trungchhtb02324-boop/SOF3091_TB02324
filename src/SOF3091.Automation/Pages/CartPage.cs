using OpenQA.Selenium;

namespace SOF3091.Automation.Pages;

public sealed class CartPage : BasePage
{
    private static readonly By CartItems = By.ClassName("cart_item");
    private static readonly By CheckoutButton = By.Id("checkout");
    private static readonly By ContinueShoppingButton = By.Id("continue-shopping");

    public CartPage(IWebDriver driver, int waitSeconds = 10) : base(driver, waitSeconds) { }

    public int ItemCount => Driver.FindElements(CartItems).Count;

    public bool ContainsBackpack() =>
        Driver.FindElements(CartItems).Any(item =>
            item.Text.Contains("Sauce Labs Backpack", StringComparison.OrdinalIgnoreCase));

    public void RemoveBackpack() => Click(By.Id("remove-sauce-labs-backpack"));

    public void Checkout() => Click(CheckoutButton);

    public void ContinueShopping() => Click(ContinueShoppingButton);
}
