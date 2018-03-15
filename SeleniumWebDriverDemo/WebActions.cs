// WebActions.cs

// This class encapsulates the Selenium WebDriver stuff.
// (http://www.seleniumhq.org/)

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
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
        /// Close the browser, quit.
        /// </summary>
        public static void CloseBrowser()
        {
            Driver.Quit();
            _driver = null;
        }


    }
}
