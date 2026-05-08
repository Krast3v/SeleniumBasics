using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumBasics;

public class Tests
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void GoogleTitleIsCorrect()
    {
        driver.Navigate().GoToUrl("https://www.google.com");
        string title = driver.Title;
        Assert.That(title, Does.Contain("Google"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
