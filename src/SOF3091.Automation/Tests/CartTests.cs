using NUnit.Framework;
using SOF3091.Automation.Pages;

namespace SOF3091.Automation.Tests;

[TestFixture]
public sealed class CartTests : BaseTest
{
    private InventoryPage LoginAsStandardUser()
    {
        new LoginPage(Driver, Config.ExplicitWaitSeconds)
            .Open(Config.BaseUrl)
            .Login("standard_user", "secret_sauce");

        return new InventoryPage(Driver, Config.ExplicitWaitSeconds);
    }

    [Test]
    [Category("Regression")]
    public void AddProduct_ShouldUpdateCartBadgeAndCartContents()
    {
        var inventory = LoginAsStandardUser();
        Assert.That(inventory.IsLoaded(), Is.True);

        inventory.AddBackpackToCart();
        Assert.That(inventory.CartCount, Is.EqualTo("1"));

        inventory.OpenCart();
        var cart = new CartPage(Driver, Config.ExplicitWaitSeconds);
        Assert.Multiple(() =>
        {
            Assert.That(cart.ItemCount, Is.EqualTo(1));
            Assert.That(cart.ContainsBackpack(), Is.True);
        });
    }

    [Test]
    [Category("Regression")]
    public void RemoveProduct_ShouldEmptyCart()
    {
        var inventory = LoginAsStandardUser();
        inventory.AddBackpackToCart();
        inventory.OpenCart();

        var cart = new CartPage(Driver, Config.ExplicitWaitSeconds);
        cart.RemoveBackpack();

        Assert.That(cart.ItemCount, Is.Zero);
    }

    [Test]
    [Category("Regression")]
    public void Inventory_ShouldDisplaySixProducts()
    {
        var inventory = LoginAsStandardUser();

        Assert.That(inventory.ProductCount, Is.EqualTo(6));
    }
}
