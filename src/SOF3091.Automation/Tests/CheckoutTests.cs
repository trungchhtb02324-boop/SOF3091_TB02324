using NUnit.Framework;
using SOF3091.Automation.Pages;

namespace SOF3091.Automation.Tests;

[TestFixture]
public sealed class CheckoutTests : BaseTest
{
    [Test]
    [Category("EndToEnd")]
    public void Checkout_WithValidCustomerInformation_ShouldCompleteOrder()
    {
        new LoginPage(Driver, Config.ExplicitWaitSeconds)
            .Open(Config.BaseUrl)
            .Login("standard_user", "secret_sauce");

        var inventory = new InventoryPage(Driver, Config.ExplicitWaitSeconds);
        inventory.AddBackpackToCart();
        inventory.OpenCart();

        var cart = new CartPage(Driver, Config.ExplicitWaitSeconds);
        Assert.That(cart.ItemCount, Is.EqualTo(1));
        cart.Checkout();

        var checkout = new CheckoutPage(Driver, Config.ExplicitWaitSeconds);
        checkout.EnterCustomerInformation("Hoang", "Trung", "700000");
        checkout.ContinueToOverview();
        checkout.FinishOrder();

        Assert.That(checkout.ConfirmationMessage, Is.EqualTo("Thank you for your order!"));
    }

    [Test]
    [Category("Negative")]
    public void Checkout_WithoutFirstName_ShouldShowValidationError()
    {
        new LoginPage(Driver, Config.ExplicitWaitSeconds)
            .Open(Config.BaseUrl)
            .Login("standard_user", "secret_sauce");

        var inventory = new InventoryPage(Driver, Config.ExplicitWaitSeconds);
        inventory.AddBackpackToCart();
        inventory.OpenCart();

        new CartPage(Driver, Config.ExplicitWaitSeconds).Checkout();

        var checkout = new CheckoutPage(Driver, Config.ExplicitWaitSeconds);
        checkout.EnterCustomerInformation("", "Trung", "700000");
        checkout.ContinueToOverview();

        Assert.That(checkout.GetErrorMessage(), Does.Contain("First Name is required"));
    }
}
