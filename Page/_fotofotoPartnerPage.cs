using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Page
{
   public  class _fotofotoPartnerPage : BasePage
    {
        private IWebElement searchInput => Driver.FindElement(By.Id("q"));
        private IWebElement searchButton => Driver.FindElement(By.CssSelector(".icon-search"));
        private IWebElement resultList => Driver.FindElement(By.CssSelector("body > div.site.sticked > div.site-center > div > div > div.products-list > div > div.details-1 > h2 > a"));
        private IReadOnlyCollection<IWebElement> checkpages => Driver.FindElements(By.CssSelector(".info-link"));

        public _fotofotoPartnerPage(IWebDriver webDriver) : base(webDriver) { }
        public void SendKey(string searchtext) 
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => searchInput.Displayed);
            searchInput.Clear();
            searchInput.SendKeys(searchtext);
            searchButton.Click(); 
        }
        public void GoToResults(string item)
        {
            if (resultList.Text.Equals(item))
            {
                resultList.Click();
            }
        }
        public void ChooseRightPage(string page)
        {
            foreach(IWebElement pages in checkpages)
            {
                if (page.Equals(pages.Text))
                {
                    pages.Click();
                    break;
                }
            }
        }
    }
    
}
