using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class LoginTests
{
    private IWebDriver driver;
    private LoginPage loginPage;

    [SetUp]
    public void Setup()
    {
        driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        loginPage = new LoginPage(driver);
    }

    [Test]
    public void SuccessfulLoginRedirectsToSecurePage()
    {
        loginPage.Open();
        loginPage.Login("tomsmith", "SuperSecretPassword!");
        Assert.That(driver.Url, Does.Contain("/secure"),
            "Successful login should redirect to /secure");
    }

    [Test]
    public void SuccessfulLoginShowsSuccessMessage()
    {
        loginPage.Open();
        loginPage.Login("tomsmith", "SuperSecretPassword!");
        Assert.That(loginPage.GetFlashMessage(), Does.Contain("You logged into a secure area!"),
            "Successful login should show success flash message");
    }

    [Test]
    public void InvalidPasswordShowsErrorMessage()
    {
        loginPage.Open();
        loginPage.Login("tomsmith", "wrongpassword");
        Assert.That(loginPage.GetFlashMessage(), Does.Contain("Your password is invalid!"),
            "Wrong password should show error flash message");
    }

    [Test]
    public void InvalidUsernameShowsErrorMessage()
    {
        loginPage.Open();
        loginPage.Login("wronguser", "SuperSecretPassword!");
        Assert.That(loginPage.GetFlashMessage(), Does.Contain("Your username is invalid!"),
            "Wrong username should show error flash message");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
