using OpenQA.Selenium;

namespace SOF3091.Automation.Pages;

public sealed class InventoryPage : BasePage
{
    private static readonly By Title = By.CssSelector("[data-test='title']");
    private static readonly By CartLink = By.ClassName("shopping_cart_link");
    private static readonly By CartBadge = By.ClassName("shopping_cart_badge");
    private static readonly By InventoryItems = By.ClassName("inventory_item");

    public InventoryPage(IWebDriver driver, int waitSeconds = 10) : base(driver, waitSeconds) { }

    public bool IsLoaded() => WaitVisible(Title).Text == "Products";

    public int ProductCount => Driver.FindElements(InventoryItems).Count;

    public void AddBackpackToCart() => Click(By.Id("add-to-cart-sauce-labs-backpack"));

    public void RemoveBackpackFromInventory() => Click(By.Id("remove-sauce-labs-backpack"));

    public string CartCount => Driver.FindElements(CartBadge).FirstOrDefault()?.Text ?? "0";

    public void OpenCart() => Click(CartLink);
}
