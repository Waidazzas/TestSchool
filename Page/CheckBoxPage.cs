using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Page
{
    class CheckBoxPage : BasePage
    {
        private IWebElement resultElement => Driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> checkboxes => Driver.FindElements(By.CssSelector(".cb1-element"));
        IWebElement button => Driver.FindElement(By.Id("check1"));

        public CheckBoxPage(IWebDriver webDriver) : base(webDriver) { }

        public void FirstCheckBox()
        {
            ClickOnCheckBox(true);
            Assert.IsTrue("Success - Check box is checked".Equals(resultElement.Text), $"text is not the same, actual text is {resultElement.Text}");
        }
        public void ClickOnManyBoxes()
        {
            ClickOnCheckBox(false);
            CheckAllCheckBoxes(checkboxes);
            Assert.IsTrue(IsButtonWithValue(button, "Uncheck All"), "text is not correct");
        }
        public void ClickButton()
        {
            ClickOnCheckBox(false);
            CheckButtonValue(button , checkboxes);
            AfterClickCheck(checkboxes , button);
        }
        private static void ClickOnCheckBox(bool shouldBeCheck)
        {
            IWebElement FirstCheckbox = Driver.FindElement(By.Id("isAgeSelected"));
            if (FirstCheckbox.Selected != shouldBeCheck)
            {
                FirstCheckbox.Click();
            }
        }
        private static void CheckAllCheckBoxes(IReadOnlyCollection<IWebElement> checkboxes)
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }
        private static bool IsButtonWithValue(IWebElement button , string value)
        {
            return value.Equals(button.GetAttribute("value"));
        }
        private static void CheckButtonValue(IWebElement button, IReadOnlyCollection<IWebElement> checkboxes)
        {
            if (!IsButtonWithValue(button, "Uncheck All"))
            {
                CheckAllCheckBoxes(checkboxes);
            }
            button.Click();
        }
        private static void AfterClickCheck(IReadOnlyCollection<IWebElement> checkboxes, IWebElement button)
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                Assert.IsFalse(checkbox.Selected);
            }
            Assert.IsTrue(IsButtonWithValue(button, "Check All"), "text is not correct");
        }
    }
}
