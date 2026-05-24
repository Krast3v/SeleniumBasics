using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class CheckboxTests
{
    private IWebDriver driver;
    private CheckboxPage checkboxPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        checkboxPage = new CheckboxPage(driver);
    }

    [Test]
    public void Should_BeChecked_When_CheckboxOneIsChecked()
    {
        // Arrange
        checkboxPage.Open();

        // Act
        checkboxPage.CheckCheckbox(0);

        // Assert
        Assert.That(checkboxPage.IsChecked(0), Is.True,
            "Checkbox 1 should be checked after calling CheckCheckbox");
    }

    [Test]
    public void Should_BeUnchecked_When_CheckboxTwoIsUnchecked()
    {
        // Arrange
        checkboxPage.Open();

        // Act
        checkboxPage.UncheckCheckbox(1);

        // Assert
        Assert.That(checkboxPage.IsChecked(1), Is.False,
            "Checkbox 2 should be unchecked after calling UncheckCheckbox");
    }

    [Test]
    public void Should_BeCheckedByDefault_When_PageLoads()
    {
        // Arrange + Act
        checkboxPage.Open();

        // Assert
        Assert.That(checkboxPage.IsChecked(1), Is.True,
            "Checkbox 2 should be checked by default on page load");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
