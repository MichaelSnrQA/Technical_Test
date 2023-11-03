namespace PSL.TechnicalTest.ApplicationUnderTest.Pages;

public class ExamplePage
{
    public static By NewsPage = By.XPath("//*[contains(@class,'nw-c-news-navigation')]");
    public static By SearchBar = By.XPath("(//span[contains(text(),'Search BBC')])[2]");
    public static By SearchInput = By.XPath("//input[@id='searchInput']");
    public static By SearchButton = By.XPath("//button[@id='searchButton']");
    public static By Title(int index,string word) => By.XPath($"(//span[contains(text(),'{word}')])[{index}]");

}
