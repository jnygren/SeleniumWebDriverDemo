// WebAccess.cs

using System;
using System.Windows;
using System.Threading;
using NLog;

namespace SeleniumWebDriverDemo
{
    class WebAccess
    {
        private static readonly string GoogleURL = "https://www.google.com/";
        private Logger logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// c'tor
        /// </summary>
        public WebAccess()
        {
            //GoogleDemo();
        }


        public void GoogleDemo()
        {
            String searchString = "Selenium";
            String ENTER = OpenQA.Selenium.Keys.Enter;

            WebActions.OpenUrl(GoogleURL);
            // wait
            Thread.Sleep(2000);

            //// Check for page title
            //if (WebActions.GetTitle() != "Google")
            //    logger.Error("Wrong page Title.");

            // Google Search Page
            if (WebActions.WaitForTheElement(GoogleSearchPage.TxtSearchText))
                logger.Info("  Successfully reached 'Google Search' page.");

            // Enter search string (slowly)
            WebActions.EnterText(GoogleSearchPage.TxtSearchText, "");
            foreach (char key in searchString.ToCharArray())
            {
                WebActions.AppendText(GoogleSearchPage.TxtSearchText, "" + key, 300);
            }
            Thread.Sleep(2000);
            WebActions.AppendText(GoogleSearchPage.TxtSearchText, ENTER, 100);

            //// Check for page title
            //if (WebActions.GetTitle() != "Selenium - Google Search")
            //    logger.Error("Wrong page Title.");

            Thread.Sleep(5000);
            WebActions.CloseBrowser();
        }
    }
}
