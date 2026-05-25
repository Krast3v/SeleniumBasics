using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class AlertTests
{
    private IWebDriver driver;
    private AlertPage alertPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        alertPage = new AlertPage(driver);
    }

    [Test]
    public void Should_ShowSuccessResult_When_SimpleAlertAccepted()
    {
        // Arrange
        alertPage.Open();

        // Act
        alertPage.TriggerSimpleAlert();
        alertPage.AcceptAlert();

        // Assert
        Assert.That(alertPage.GetResult(), Does.Contain("You successfully clicked an alert"),
            "Accepting simple alert should show success result");
    }

    [Test]
    public void Should_ShowOkResult_When_ConfirmAlertAccepted()
    {
        // Arrange
        alertPage.Open();

        // Act
        alertPage.TriggerConfirmAlert();
        alertPage.AcceptAlert();

        // Assert
        Assert.That(alertPage.GetResult(), Does.Contain("You clicked: Ok"),
            "Accepting confirm alert should show Ok result");
    }

    [Test]
    public void Should_ShowCancelResult_When_ConfirmAlertDismissed()
    {
        // Arrange
        alertPage.Open();

        // Act
        alertPage.TriggerConfirmAlert();
        alertPage.DismissAlert();

        // Assert
        Assert.That(alertPage.GetResult(), Does.Contain("You clicked: Cancel"),
            "Dismissing confirm alert should show Cancel result");
    }

    [Test]
    public void Should_ShowTypedText_When_PromptAlertFilled()
    {
        // Arrange
        alertPage.Open();
        const string input = "Hello QA";

        // Act
        alertPage.TriggerPromptAlert();
        alertPage.TypeInPrompt(input);

        // Assert
        Assert.That(alertPage.GetResult(), Does.Contain(input),
            "Prompt alert should show the typed text in result");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
