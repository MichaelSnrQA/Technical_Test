namespace PSL.TechnicalTest.Steps;

[Binding]
public class ExampleSteps
{
    private IWebDriver driver;
    private BBCNewsPage bBCNewsPage;
    private SearchPage searchPage;

    public ExampleSteps()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        driver = new ChromeDriver(options);
        bBCNewsPage = new BBCNewsPage(driver);
        searchPage = new SearchPage(driver);
    }
    
    [Given(@"User nevigate to BBC news website")]
    public void GivenUserNevigateToBbc()
    {
        bBCNewsPage.NavigateToBBCNewsPage("https://www.bbc.co.uk/news");
    }

    
    [When(@"User verify its on BBC news website")]
    public void ThenUserVerifyItsOnBBCNewsWebsite()
    {     
        Assert.IsTrue(bBCNewsPage.IsOnBBCNewsPage(), "User can't able to nevigate to BBC News page");
    }

    [Then(@"User Click on Search bar")]
    public void ThenUserClickOfSearchBar()
    {
        searchPage.ClickSearchBar();
    }

    [Then(@"User search word ""([^""]*)""")]
    public void ThenUserSearchWord(string word)
    {
        searchPage.SearchForWord(word);
    }

    [Then(@"User verify word appear in ""([^""]*)"" title of search result")]
    public void ThenUserVerifyWordAppearInTitleOfSearchResult(string time)
    {
        string word = searchPage.GetSearchWord();
        int times = Convert.ToInt32(time);
        Assert.IsTrue(searchPage.VerifyWordInTitle(word, times), $"The title does not contain {word}");
        driver.Quit();
    }

}
