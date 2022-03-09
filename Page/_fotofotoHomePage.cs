using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace Tests.Page
{
    public class _fotofotoHomePage : BasePage
    {
        private const string PageAddress = "https://www.fotofoto.lt/";
        private IWebElement searchInput => Driver.FindElement(By.CssSelector("#s"));
        private IWebElement searchButton => Driver.FindElement(By.CssSelector("body > div.wrapper > div.header > form > input[type=submit]:nth-child(2)"));
        private IReadOnlyCollection<IWebElement> resultList => Driver.FindElements(By.CssSelector("body > div.wrapper > div.content > div.cont_cont.listas > ul > li"));
        private IReadOnlyCollection<IWebElement> dropdown => Driver.FindElements(By.CssSelector("body > div.ac_results > ul > li"));
        private IReadOnlyCollection<IWebElement> mainLineMenu => Driver.FindElements(By.CssSelector(".relative-wrapper"));
        private IReadOnlyCollection<IWebElement> chooseOption => Driver.FindElements(By.CssSelector("body > div.wrapper > div.header > table > tbody > tr > td:nth-child(2) > div > div > table > tbody > tr > td > div div > a"));
        private IWebElement advertisementPage => Driver.FindElement(By.CssSelector("body > div.wrapper > div.content > div:nth-child(75) > a:nth-child(1)"));
        private IWebElement acceptCookie => Driver.FindElement(By.CssSelector("body > div.cc_banner-wrapper > div"));

        public _fotofotoHomePage(IWebDriver webDriver) : base(webDriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }

        public void AcceptCookie()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => acceptCookie.Displayed);
            acceptCookie.FindElement(By.CssSelector("body > div.cc_banner-wrapper > div > a.cc_btn.cc_btn_accept_all")).Click();
        }
        public void SearchByCommodity(string search)
        {
            searchInput.Clear();
            searchInput.SendKeys(search);
            searchButton.Click();
        }
        public void ChoosingProduct(string item)
        {
            foreach (IWebElement result in resultList)
            {
                if (item.Equals(result.FindElement(By.CssSelector(".title")).Text))
                {
                    result.FindElement(By.CssSelector(".relative")).Click();
                    break;
                }
            }
        }
        public void SearchDropDown(string Item)
        {
            for (int i = 0; i < 2; i++)
            {
               searchInput.Click();
            }
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector("body > div.ac_results")).Displayed);
            foreach (IWebElement dropdownItem in dropdown)
            {
                if (Item.Equals(dropdownItem.FindElement(By.CssSelector("body > div.ac_results > ul > li > table > tbody > tr > td > a > span")).Text))
                {
                    dropdownItem.FindElement(By.CssSelector(".tableeee")).Click();
                    break;
                }
            }
        }
        public void MoveToMainLineMenu(string choose)
        {
            foreach (IWebElement MainLine in mainLineMenu)
            {
                if (choose.Equals(MainLine.FindElement(By.CssSelector(".line")).Text))
                {
                    Actions builder = new Actions(Driver);
                    builder.MoveToElement(MainLine.FindElement(By.CssSelector(".line"))).Perform();
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                    wait.Until(d => d.FindElement(By.CssSelector(".sub-nav")).Displayed);
                    break;
                }
            }
        }
        public void ClickOnOption(string option)
        {
            foreach(IWebElement clickOption in chooseOption)
            {
                if (option.Equals(clickOption.Text))
                {
                    clickOption.Click();
                    break;
                }
            }
        }
        public void ClickOnPartnerPage()
        {
            advertisementPage.Click();
        }
    }
}
