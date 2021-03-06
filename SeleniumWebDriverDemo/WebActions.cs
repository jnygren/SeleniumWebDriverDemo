﻿// WebActions.cs

// This class encapsulates the Selenium WebDriver stuff.
// (http://www.seleniumhq.org/)

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.IE;
using System.Threading;
using System.Linq;
using System.IO;

namespace SeleniumWebDriverDemo
{
    class WebActions
    {
        enum Browsers { Default, Firefox, Chrome, IE, Edge, Other };

        private static Browsers _browser;

        private static IWebDriver _driver = null;
        private static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    switch (_browser)
                    {
                        case Browsers.Firefox:
                            _driver = new FirefoxDriver();
                            break;
                        case Browsers.Chrome:
                            _driver = new ChromeDriver();
                            break;
                        case Browsers.IE:
                        //_driver = new InternetExplorerDriver();
                        case Browsers.Edge:
                        case Browsers.Other:
                        case Browsers.Default:
                        default:
                            throw new NotImplementedException("Support for selected browser has not yet been implemented.");
                            //break;  // Unreachable code after a 'throw'.
                    }
                }
                return _driver;
            }
            set { _driver = value; }
        }

        public delegate By GetBy(string element);


        /// <summary>
        /// Select the browser to use for WebDriver
        /// </summary>
        /// <param name="browser">Default, Firefox, Chrome, IE, ...</param>
        public static void SelectBrowser(string browser)
        {
            Driver = null;  // Reset

            browser = browser.ToUpper();
            if (browser.Contains("CHROME"))
                _browser = Browsers.Chrome;
            else if (browser.Contains("FIREFOX"))
                _browser = Browsers.Firefox;
            else if (browser.Contains("IE"))
                _browser = Browsers.IE;
            else if (browser.Contains("EDGE"))
                _browser = Browsers.Edge;
            else
                _browser = Browsers.Default;
        }


        /// <summary>
        /// For Debug - I just need a place to test things at the driver level.
        /// </summary>
        /// <param name="by">By parameter (optional)</param>
        public static void ForDebug(By by = null)
        {
            IWebElement e = Driver.FindElement(by);
            string tag = e.TagName;
            string text = e.Text;
        }

        
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


        /// <summary>
        /// Retrieve the title of the current browser window
        /// </summary>
        /// <returns>The window title.</returns>
        public static string GetTitle()
        {
            return Driver.Title;
        }


        /*****************************************************************************************\
            Methods to be implemented yet
Page.SelectDropDownByValue(ddlDay, date.Day.ToString());
Page.SelectDropDownByVisibleText(ddlMonth, date.Month.ToString());
Page.GetOptionsInSelect(pageIndex);
Page.Click(LoginPage.NextButton);
Page.GetText(LoginPage.OrgName)))
Page.CheckCheckboxesInPages(StaffMemberPage.DdlPageSelector, StaffMemberPage.GetChkBoxForStaff(staff), true);
Page.GetTextList(StaffMemberPage.StaffInfoHeader);

        \*****************************************************************************************/


        /// <summary>
        /// Enter Text - Send text to specified field, overwriting current field contents
        /// </summary>
        /// <param name="field">The field to which to send the text.</param>
        /// <param name="value">The text to be sent.</param>
        public static void EnterText(string field, string value)
        {
            EnterText(By.Name(field), value);
        }


        /// <summary>
        /// Enter Text - Send text to specified field, overwriting current field contents
        /// </summary>
        /// <param name="field">The field to which to send the text.</param>
        /// <param name="value">The text to be sent.</param>
        public static void EnterText(By field, string value)
        {
            if (WaitForTheElement(field))
            {
                IWebElement element = Driver.FindElement(field);
                element.Clear();
                AppendText(field, value);
            }
        }


        /// <summary>
        /// Append Text - Send text to specified field. Do not clear field first.
        /// </summary>
        /// <param name="field">The field to which to send the text.</param>
        /// <param name="value">The text to be sent.</param>
        /// <param name="msTimeout">Delay before returning control to caller.</param>
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
        /// Click specified element
        /// </summary>
        /// <param name="by">element to click.</param>
        public static void Click(By by)
        {
            if (WaitForTheElement(by))
                Driver.FindElement(by).Click();
        }


        /// <summary>
        /// Check checkbox or radio button
        /// </summary>
        /// <param name="by">Element to check or uncheck.</param>
        /// <param name="check">'true' (default) to check; 'false' to clear.</param>
        public static void CheckCheckbox(By by, bool check = true)
        {
            if (WaitForTheElement(by))
                if (Driver.FindElement(by).Selected != check)
                    Click(by);
        }


        /// <summary>
        /// Get Text - Retrieve the text content of an element.
        /// </summary>
        /// <param name="by">The element to retrieve text from.</param>
        /// <returns>The text contained in the element.</returns>
        public static string GetText(By by)
        {
            if (IsElementPresent(by))
                return Driver.FindElement(by).Text;

            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="screenshotFile">File path were screen shot will be saved.</param>
        /// <returns>Full path where screen shot file is saved.</returns>
        public static string PrintScreen(string screenshotFile = "SS.Png")
        {
            // Save a screen shot.
            string ssExt = Path.GetExtension(screenshotFile).ToUpper();
            ScreenshotImageFormat ssiFormat = ScreenshotImageFormat.Png;

            switch (ssExt)
            {
                case "JPG":
                    ssiFormat = ScreenshotImageFormat.Jpeg;
                    break;
                default:    // If not 'jpg', then make it 'png'.
                    ssiFormat = ScreenshotImageFormat.Png;
                    Path.ChangeExtension(screenshotFile, "png");
                    break;
            }

            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(screenshotFile, ssiFormat);

            return Path.GetFullPath(screenshotFile);
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
