using OpenQA.Selenium;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Tests.Page
{
    public class _fotofotoResultPage : BasePage
    {
        private IWebElement price => Driver.FindElement(By.CssSelector(".kaina"));
        private IWebElement cartPrice => Driver.FindElement(By.Id("viso_kaina"));
        private IWebElement askButton => Driver.FindElement(By.CssSelector(".i_krepseli"));
        private IWebElement productTitle => Driver.FindElement(By.CssSelector(".product_pavadinimas"));
        public _fotofotoResultPage(IWebDriver webDriver) : base(webDriver) { }
        public void VerifyPrice(string expectPrice)
        {
            Assert.AreEqual(expectPrice, price.Text, "something wrong");
        }
        public void VerifyCartPrice(string expectedCartPrice)
        {
            Assert.IsTrue(expectedCartPrice.Equals(cartPrice.Text), $"the price {cartPrice.Text} is not than expected");
        }
        public void VerifyAskWindow(string expectedText)
        {
            if (askButton.Text.Equals(expectedText))
            {
                askButton.Click();
            }
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector(".addtocart")).Displayed);
            Assert.AreEqual(expectedText, Driver.FindElement(By.CssSelector(".addtocart")).GetAttribute("value").ToString(), "expected result is not correct");
        }
        public void Wait()
        {
        }
        public void VerifyByName(string productName)
        {
            Assert.AreEqual(productName, productTitle.Text, "product name is not correct!");
        }
    }
}
