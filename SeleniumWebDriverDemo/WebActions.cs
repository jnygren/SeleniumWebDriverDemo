// WebActions.cs

// This class encapsulates the Selenium WebDriver stuff.
// (http://www.seleniumhq.org/)

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Linq;
//using OpenQA.Selenium.IE;

namespace SeleniumWebDriverDemo
{
    class WebActions
    {
        private static IWebDriver _driver = null;
        private static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new FirefoxDriver();
                    //_driver = new InternetExplorerDriver();
                }
                return _driver;
            }
            set { _driver = value; }
        }

        public delegate By GetBy(string element);


        /// <summary>
        /// Open web page in browser
        /// </summary>
        /// <param name="url">URL of page to be opened.</param>
        public static void OpenUrl(string url)
        {
            Driver.Url = url;
        }


        /// <summary>
        /// Verify that element is displayed
        /// </summary>
        /// <param name="by">Element of interest</param>
        /// <returns>'True' if element is found.</returns>
        public static bool IsElementPresent(By by)
        {
            return Driver.FindElements(by).Where(e => e.Displayed).Count() > 0;
        }


        /// <summary>
        /// Wait for element to be rendered on page
        /// </summary>
        /// <param name="by">Element of interest</param>
        /// <param name="timeout">Time (seconds) in which element is to be found</param>
        /// <returns>'True' if element is found.</returns>
        public static bool WaitForTheElement(By by, int timeout = 45)
        {
            bool found = false;

            for (int i = 0; i <= timeout; i++)
            {
                if (WebActions.IsElementPresent(by))
                {
                    found = true;
                    break;
                }
                Thread.Sleep(1000);
            }
            //Assert.Fail("Unable to find the element " + by.ToString() + " even after waiting " + timeout + " seconds");
            return found;
        }


        /*****************************************************************************************\
            Methods to be implemented yet
Page.IsElementPresent(by)

Page.SelectDropDownByValue(ddlDay, date.Day.ToString());
Page.SelectDropDownByVisibleText(ddlMonth, date.Month.ToString());
Page.GetOptionsInSelect(pageIndex);
Page.EnterText(LoginPage.SiteId, siteid);
Page.Click(LoginPage.NextButton);
Page.GetText(LoginPage.OrgName)))
Page.WaitForTheElement(LoginPage.SignInButton, 3);
Page.CheckCheckboxesInPages(StaffMemberPage.DdlPageSelector, StaffMemberPage.GetChkBoxForStaff(staff), true);
Page.GetTextList(StaffMemberPage.StaffInfoHeader);

        \*****************************************************************************************/


        public static void EnterText(string field, string value)
        {
            EnterText(By.Name(field), value);
        }


        public static void EnterText(By field, string value)
        {
            if (WaitForTheElement(field))
            {
                IWebElement element = Driver.FindElement(field);
                element.Clear();
                AppendText(field, value);
            }
        }


        public static void AppendText(By field, string value, int msTimeout = 1000)
        {
            if (WaitForTheElement(field))
            {
                IWebElement element = Driver.FindElement(field);
                element.SendKeys(value);
            }
            Thread.Sleep(msTimeout);
        }


        /// <summary>
        /// Close the browser, quit.
        /// </summary>
        public static void CloseBrowser()
        {
            Driver.Quit();
            _driver = null;
        }


    }
}
