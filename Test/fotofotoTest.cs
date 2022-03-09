using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.driver;
using Tests.Page;

namespace Tests.Test
{
    public  class fotofotoTest : BaseTest
    {

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Close();
        }
        [Test]

        public static void Test1FujifilmXt4Price()
        {
            HomePage.NavigateToPage();
            //HomePage.AcceptCookie();
            HomePage.SearchByCommodity("fujifilm xt4");
            HomePage.ChoosingProduct("Fujifilm X-T4 body (Sidabrinis)");
            ResultPage.VerifyPrice("1 366.00 €");
        }
        [Test]
        public static void Test2FujifilmXt4ManyPrice()
        {
            HomePage.NavigateToPage();
            //HomePage.AcceptCookie();
            HomePage.SearchByCommodity("fujifilm xt4");
            HomePage.ChoosingProduct("Fujifilm X-T4 body (Sidabrinis)");
            CartPage.Add5unitcart();
            ResultPage.VerifyCartPrice("Iš viso 6 830.00 €");
        }
        [Test]
        public static void Test3FujifilmXt4AskWindow()
        {
            HomePage.NavigateToPage();
            //HomePage.AcceptCookie();
            HomePage.SearchByCommodity("fujifilm xt4");
            HomePage.SearchDropDown("Fujifilm X-T4 body (Sidabrinis)");
            ResultPage.VerifyAskWindow("Teirautis");
        }
        [Test]
        public static void Test4FujifilmXt4Comparison()
        {
            HomePage.NavigateToPage();
           // HomePage.AcceptCookie();
            HomePage.MoveToMainLineMenu("Fotoaparatai");
            HomePage.ClickOnOption("Fujifilm (83)");
            //ProductPage.ChangeFilterOptions();
            ProductsPage.LookingForProduct("Fujifilm X-T30 body (Sidabrinis)");
            ProductsPage.ClickOnComparisonButton();
            ResultPage.VerifyByName("Fujifilm X-T30 body (Sidabrinis)");
        }
        [Test]
        public static void Test5FujifilmXt4CheckPartnerPage()
        {
            HomePage.NavigateToPage();
            //HomePage.AcceptCookie();
            HomePage.ClickOnPartnerPage();
            PartnerPage.SendKey("fujifilm xt4");
            PartnerPage.GoToResults("Fotoaparatas Fujifilm X-T4");
            PartnerPage.ChooseRightPage("fotofoto.lt");
            //ResultPage.VerifyByName("Fujifilm X-T4 body (Juodas)");
        }
    }
}
