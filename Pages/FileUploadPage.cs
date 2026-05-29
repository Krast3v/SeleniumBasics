using OpenQA.Selenium;

namespace SeleniumBasics.Pages;

public class FileUploadPage
{
    private readonly IWebDriver driver;

    public FileUploadPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");
    }

    public void UploadFile(string filePath)
    {
        driver.FindElement(By.Id("file-upload")).SendKeys(filePath);
        driver.FindElement(By.Id("file-submit")).Click();
    }

    public string GetUploadedFileName()
    {
        return driver.FindElement(By.Id("uploaded-files")).Text;
    }

    public bool IsUploadSuccessful()
    {
        return driver.FindElement(By.CssSelector("h3")).Text == "File Uploaded!";
    }
}
