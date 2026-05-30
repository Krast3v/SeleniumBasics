using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class HoverTests
{
    private IWebDriver driver;
    private HoverPage hoverPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        hoverPage = new HoverPage(driver);
    }

    [Test]
    public void Should_ShowCaption_When_HoveringOverFirstAvatar()
    {
        // Arrange
        hoverPage.Open();

        // Act
        hoverPage.HoverOverAvatar(0);

        // Assert
        Assert.That(hoverPage.GetAvatarCaption(0), Does.Contain("user1"),
            "Hovering over first avatar should show user1 caption");
    }

    [Test]
    public void Should_ShowCaption_When_HoveringOverSecondAvatar()
    {
        // Arrange
        hoverPage.Open();

        // Act
        hoverPage.HoverOverAvatar(1);

        // Assert
        Assert.That(hoverPage.GetAvatarCaption(1), Does.Contain("user2"),
            "Hovering over second avatar should show user2 caption");
    }

    [TestCase(0, "user1")]
    [TestCase(1, "user2")]
    [TestCase(2, "user3")]
    public void Should_ShowCorrectCaption_When_HoveringOverAvatar(int index, string expectedUser)
    {
        // Arrange
        hoverPage.Open();

        // Act
        hoverPage.HoverOverAvatar(index);

        // Assert
        Assert.That(hoverPage.GetAvatarCaption(index), Does.Contain(expectedUser),
            $"Hovering over avatar {index} should show {expectedUser} caption");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
