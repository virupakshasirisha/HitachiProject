using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using HitachiProject.Common;
using System.IO;

[TestFixture]
public class HitachiSolutionsTest
{
    IWebDriver driver;
    string url = "https://global.hitachi-solutions.com/"; //App url
    string driverPath = "C:/Users/virup/source/repos/HitachiProject/HitachiProject/chromedriver"; //Replace driver path
    Navigation navigation = new Navigation();
    Search search = new Search();

    //Initilizing the Test
    [SetUp]
    public void SetupTest()
    {
        // Launch the Chrome browser. 
        driver = new ChromeDriver(driverPath);

        // Navigate to the application
        navigation.NavigateToApplication(url, driver);
    }

    //Test to verify Serach functionality 
    [Test]
    public void SearchForKeywords()
    {
        search.GlobalSearch("digital", driver);
       
        // Verify that the search result is displayed
        Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Digital')]")).Displayed);
    }

    //Test to verify Search results no values
    [Test]
    public void SearchReturnsNoResults()
    {
        search.GlobalSearch("Fridge", driver);

        // Verify that the search doesnot return any result
        Assert.IsTrue(driver.FindElement(By.XPath("//h4[contains(text(),\"Sorry, your search didn't return any results.\")]")).Displayed);

    }

    //Test to verify navigation to second search results page
    [Test]
    public void NavigateToSecondPageOfSearchResults()
    {
        search.GlobalSearch("digital", driver);

        search.ClickOnPageButton("2", driver);
        string url = driver.Url;
        Assert.IsTrue(url.Contains("/page/2/"));

    }

    //Closing the Test
    [TearDown]
    public void TeardownTest()
    {
        // Close the browser
        driver.Close();
    }
}
