namespace PSL.TechnicalTest.Steps;

[Binding]
public class ExampleSteps
{
    private IWebDriver driver;
    int timeoutInSeconds = 10;
    [When(@"User nevigate to BBC news website")]
    public void GivenUserNevigateToBbc()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl("https://www.bbc.co.uk/news");
    }

    [Then(@"User verify its on BBC news website")]
    public void ThenUserVerifyItsOnBBCNewsWebsite()
    {
        var newsPageElement = HelperClass.WaitForElementToBeVisible(driver, ExamplePage.NewsPage, timeoutInSeconds);
        Assert.IsTrue(newsPageElement.Displayed, "User can't able to nevigate to BBC News page");
    }

    [Then(@"User Click on Search bar")]
    public void ThenUserClickOfSearchBar()
    {
        driver.FindElement(ExamplePage.SearchBar).Click();
        var searchInputElement = HelperClass.WaitForElementToBeVisible(driver, ExamplePage.SearchInput, timeoutInSeconds);
        Assert.IsTrue(searchInputElement.Displayed, "User can't able to nevigate to Search page");
    }

    [Then(@"User search word ""([^""]*)""")]
    public void ThenUserSearchWord(string word)
    {
        driver.FindElement(ExamplePage.SearchInput).SendKeys(word);
        driver.FindElement(ExamplePage.SearchButton).Click();
    }

    [Then(@"User verify word appear in ""([^""]*)"" title of search result")]
    public void ThenUserVerifyWordAppearInTitleOfSearchResult(string time)
    {
        string word = driver.FindElement(ExamplePage.SearchInput).GetAttribute("value");
        int times = Convert.ToInt32(time);
        for (int i = 1; i <= times; i++)
        {
            var title=driver.FindElement(ExamplePage.Title(i,word));
            Assert.IsTrue(title.Displayed, $"The title number {i} does not contain {word}");
        }
        driver.Quit();
    }

}
