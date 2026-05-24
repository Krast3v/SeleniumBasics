using OpenQA.Selenium;

namespace SeleniumBasics.Pages;

public class CheckboxPage
{
    private readonly IWebDriver driver;

    public CheckboxPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
    }

    public void CheckCheckbox(int index)
    {
        var checkboxes = driver.FindElements(By.CssSelector("input[type='checkbox']"));
        if (!checkboxes[index].Selected)
            checkboxes[index].Click();
    }

    public void UncheckCheckbox(int index)
    {
        var checkboxes = driver.FindElements(By.CssSelector("input[type='checkbox']"));
        if (checkboxes[index].Selected)
            checkboxes[index].Click();
    }

    public bool IsChecked(int index)
    {
        var checkboxes = driver.FindElements(By.CssSelector("input[type='checkbox']"));
        return checkboxes[index].Selected;
    }
}
