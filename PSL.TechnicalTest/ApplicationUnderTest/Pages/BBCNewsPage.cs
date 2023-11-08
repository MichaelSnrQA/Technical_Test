
namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    public class BBCNewsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        private By NewsPage = By.XPath("//*[contains(@class,'nw-c-news-navigation')]");

        public BBCNewsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void NavigateToBBCNewsPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public bool IsOnBBCNewsPage()
        {
            var newsPageElement = HelperClass.WaitForElementToBeVisible(driver, NewsPage);
            if (newsPageElement.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
