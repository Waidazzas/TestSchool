using OpenQA.Selenium;


namespace Tests.Page
{
    public class BasePage
    {
        protected static IWebDriver Driver;

        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
