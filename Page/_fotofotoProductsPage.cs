using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Page
{
    public class _fotofotoProductsPage : BasePage
    {
        private IReadOnlyCollection<IWebElement> productNames => Driver.FindElements(By.CssSelector("body > div.wrapper > div.content > div.cont_cont.listas > ul > li"));
        private IWebElement productFilterByNumbers => Driver.FindElement(By.Id("msdrpdd21_titletext"));
        private IWebElement biggestFilterNumber => Driver.FindElement(By.Id("msdrpdd21_msa_3"));
        private IWebElement comparrisingButton => Driver.FindElement(By.CssSelector("body > div.wrapper > div.content > div.cont_cont.text > div.simple_text > div.product_desc > a.palyginti"));

        public _fotofotoProductsPage(IWebDriver webDriver) : base(webDriver) { }
        public void ChangeFilterOptions()
        {
            productFilterByNumbers.Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => biggestFilterNumber.Displayed);
            biggestFilterNumber.Click();
        }
        public void LookingForProduct(string productName)
        {
            foreach (IWebElement products in productNames)
            {

                if (productName.Equals(products.FindElement(By.CssSelector(".title")).Text))
                {
                    products.FindElement(By.CssSelector(".relative")).Click();
                    break;
                }
            }
        }
        public void ClickOnComparisonButton()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => comparrisingButton.Displayed);
            comparrisingButton.Click();
        }

    }
}
