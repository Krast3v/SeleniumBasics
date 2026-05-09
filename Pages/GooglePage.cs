using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasics.Pages;

public class GooglePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public GooglePage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://www.google.com");
    }

    public string GetTitle()
    {
        return driver.Title;
    }

    public void Search(string query)
    {
        IWebElement searchBox = wait.Until(d =>
        {
            var el = d.FindElement(By.CssSelector("textarea[name='q']"));
            return el.Displayed && el.Enabled ? el : null;
        });

        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].value='" + query + "';", searchBox);
        searchBox.Submit();

        wait.Until(d => !d.Title.Equals("Google") && d.Title.Length > 0);
    }
}
