using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasics.Pages;

public class AlertPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public AlertPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
    }

    public void TriggerSimpleAlert()
    {
        driver.FindElement(By.CssSelector("button[onclick='jsAlert()']")).Click();
    }

    public void TriggerConfirmAlert()
    {
        driver.FindElement(By.CssSelector("button[onclick='jsConfirm()']")).Click();
    }

    public void TriggerPromptAlert()
    {
        driver.FindElement(By.CssSelector("button[onclick='jsPrompt()']")).Click();
    }

    public void AcceptAlert()
    {
        wait.Until(d => d.SwitchTo().Alert() != null);
        driver.SwitchTo().Alert().Accept();
    }

    public void DismissAlert()
    {
        wait.Until(d => d.SwitchTo().Alert() != null);
        driver.SwitchTo().Alert().Dismiss();
    }

    public void TypeInPrompt(string text)
    {
        wait.Until(d => d.SwitchTo().Alert() != null);
        driver.SwitchTo().Alert().SendKeys(text);
        driver.SwitchTo().Alert().Accept();
    }

    public string GetResult()
    {
        return wait.Until(d => d.FindElement(By.Id("result"))).Text;
    }
}
