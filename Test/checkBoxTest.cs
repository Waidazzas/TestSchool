using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Page;

namespace Tests.Test
{
    class checkBoxTest
    {
        private static ChromeDriver driver;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Close();
        }
        [TestCase (TestName = "Test1OneCheckBox")]
        public static void Test1oneCheckBox()
        {
            CheckBoxPage page = new CheckBoxPage(driver);

            page.FirstCheckBox();

        }
        [TestCase(TestName = "Test2ManyCheckBoxes")]
        public static void Test2ManyCheckBoxes()
        {
            CheckBoxPage page = new CheckBoxPage(driver);
            page.ClickOnManyBoxes();
        }
        [TestCase(TestName = "CheckButtonValue")]
        public static void CheckButtonValue()
        {
            CheckBoxPage page = new CheckBoxPage(driver);
            page.ClickButton();
        }
    }
}
