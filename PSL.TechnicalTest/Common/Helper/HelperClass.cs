namespace PSL.TechnicalTest.Common.Helper
{
    public class HelperClass
    {
        public static IWebElement WaitForElementToBeVisible(IWebDriver driver, By by, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(by);
                    if (element.Displayed)
                        return element;
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }
    }
}
