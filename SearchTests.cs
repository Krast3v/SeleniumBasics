using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class SearchTests
{
    private IWebDriver driver;
    private GooglePage googlePage;

    [OneTimeSetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        googlePage = new GooglePage(driver);
    }

    [Test]
    public void SearchForNUnit()
    {
        googlePage.Open();
        googlePage.Search("NUnit");
        Assert.That(driver.Title, Does.Contain("NUnit"));
    }

    [Test]
    public void SearchForCSharp()
    {
        googlePage.Open();
        googlePage.Search("CSharp programming");
        Assert.That(driver.Title, Does.Contain("CSharp"));
    }

    [TestCase("Selenium")]
    [TestCase("NUnit")]
    [TestCase("CSharp")]
    public void SearchReturnsResultsFor(string query)
    {
        googlePage.Open();
        googlePage.Search(query);
        Assert.That(driver.Title, Does.Contain(query));
    }


    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
