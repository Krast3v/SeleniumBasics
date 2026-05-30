using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class FileUploadTests
{
    private IWebDriver driver;
    private FileUploadPage fileUploadPage;
    private string testFilePath;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        fileUploadPage = new FileUploadPage(driver);
        testFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "testfile.txt");
        File.WriteAllText(testFilePath, "test content");
    }

    [Test]
    public void Should_ShowUploadedFileName_When_FileIsUploaded()
    {
        // Arrange
        fileUploadPage.Open();

        // Act
        fileUploadPage.UploadFile(testFilePath);

        // Assert
        Assert.That(fileUploadPage.GetUploadedFileName(), Does.Contain("testfile.txt"),
            "Uploaded file name should appear on the page");
    }

    [Test]
    public void Should_ShowSuccessMessage_When_FileIsUploaded()
    {
        // Arrange
        fileUploadPage.Open();

        // Act
        fileUploadPage.UploadFile(testFilePath);

        // Assert
        Assert.That(fileUploadPage.IsUploadSuccessful(), Is.True,
            "Page should show 'File Uploaded!' after successful upload");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
        if (File.Exists(testFilePath))
            File.Delete(testFilePath);
    }
}
