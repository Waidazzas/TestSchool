using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.driver;
using Tests.Page;
using Tests.tools;

namespace Tests.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        protected static _fotofotoCartPage CartPage;
        protected static _fotofotoHomePage HomePage;
        protected static _fotofotoPartnerPage PartnerPage;
        protected static _fotofotoProductsPage ProductsPage;
        protected static _fotofotoResultPage ResultPage;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            CartPage = new _fotofotoCartPage(driver);
            HomePage = new _fotofotoHomePage(driver);
            PartnerPage = new _fotofotoPartnerPage(driver);
            ProductsPage = new _fotofotoProductsPage(driver);
            ResultPage = new _fotofotoResultPage(driver);
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreeshot(driver);
            }
        }


        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}