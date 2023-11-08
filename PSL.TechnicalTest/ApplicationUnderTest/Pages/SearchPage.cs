namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    public class SearchPage
    {
        private IWebDriver driver;

        private By SearchBar = By.XPath("(//span[contains(text(),'Search BBC')])[2]");
        private By SearchInput = By.XPath("//input[@id='searchInput']");
        private By SearchButton = By.XPath("//button[@id='searchButton']");
        private By Title(int index, string word) => By.XPath($"(//span[contains(text(),'{word}')])[{index}]");


        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickSearchBar()
        {
            HelperClass.WaitForElementToBeVisible(driver, SearchBar).Click();
        }
        
        public void SearchForWord(string word)
        {
            var searchInputElement = HelperClass.WaitForElementToBeVisible(driver, SearchInput);
            searchInputElement.SendKeys(word);
            driver.FindElement(SearchButton).Click();
        }

        public bool VerifyWordInTitle(string word, int times)
        { 
            for (int i = 1; i <= times; i++)
            {
                var title = HelperClass.WaitForElementToBeVisible(driver, Title(i, word));
                if(!title.Displayed || !title.Text.Contains(word))
                {
                    return false;
                }
            }
            return true;
        }

        public string GetSearchWord() {
            return HelperClass.WaitForElementToBeVisible(driver, SearchInput).GetAttribute("value");
        }
    }
}
