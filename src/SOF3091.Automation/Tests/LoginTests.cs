using NUnit.Framework;
using SOF3091.Automation.Pages;

namespace SOF3091.Automation.Tests;

[TestFixture]
public sealed class LoginTests : BaseTest
{
    [Test]
    [Category("Smoke")]
    public void Login_WithValidCredentials_ShouldOpenInventory()
    {
        var login = new LoginPage(Driver, Config.ExplicitWaitSeconds);
        login.Open(Config.BaseUrl).Login("standard_user", "secret_sauce");

        Assert.That(new InventoryPage(Driver, Config.ExplicitWaitSeconds).IsLoaded(), Is.True);
    }

    [Test]
    [Category("Negative")]
    public void Login_WithInvalidPassword_ShouldShowError()
    {
        var login = new LoginPage(Driver, Config.ExplicitWaitSeconds);
        login.Open(Config.BaseUrl).Login("standard_user", "wrong_password");

        Assert.That(login.GetErrorMessage(), Does.Contain("Username and password do not match"));
    }

    [Test]
    [Category("Negative")]
    public void Login_WithLockedOutUser_ShouldShowLockedOutMessage()
    {
        var login = new LoginPage(Driver, Config.ExplicitWaitSeconds);
        login.Open(Config.BaseUrl).Login("locked_out_user", "secret_sauce");

        Assert.That(login.GetErrorMessage(), Does.Contain("locked out"));
    }

    [Test]
    [Category("Negative")]
    public void Login_WithEmptyCredentials_ShouldShowRequiredFieldsMessage()
    {
        var login = new LoginPage(Driver, Config.ExplicitWaitSeconds);
        login.Open(Config.BaseUrl).Login("", "");

        Assert.That(login.GetErrorMessage(), Does.Contain("Username is required"));
    }
}
