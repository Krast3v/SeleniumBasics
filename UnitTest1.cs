using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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

    [Test]
    public void GoogleSearchReturnsResults()
    {
        driver.Navigate().GoToUrl("https://www.google.com");
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement searchBox = wait.Until(d => {
            var el = d.FindElement(By.CssSelector("textarea[name='q']"));
            return el.Displayed && el.Enabled ? el : null;
        });
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].value='Selenium C#';", searchBox);
        searchBox.Submit();
        wait.Until(d => d.Title.Contains("Selenium"));
        Assert.That(driver.Title, Does.Contain("Selenium"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
