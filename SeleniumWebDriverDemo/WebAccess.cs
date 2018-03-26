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
        private static readonly string UIMN_URL = "http://uimn.org/uimn/";
        private Logger logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// c'tor
        /// </summary>
        public WebAccess()
        {
            //GoogleDemo();
        }


        /// <summary>
        /// Google Demo - Search on 'Selenium'
        /// </summary>
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


        /// <summary>
        /// Unemployment Insurance Request - Use WebDriver to make a payment request
        /// </summary>
        public void UIRequest()
        {
            logger.Info("In WebAccess.UIRequest().");

            // Go to UI website
            WebActions.OpenUrl(UIMN_URL);

            // Check for page title
            string pageTitle = WebActions.GetTitle();
            if (pageTitle.Contains(UIMNHome.title))
                logger.Info(string.Format("Found page title \"{0}\".", pageTitle));
            else
                logger.Error(string.Format("Wrong page Title. Expected {0}, found {1}", UIMNHome.title, pageTitle));

            // Confirm correct page
            if (WebActions.WaitForTheElement(UIMNHome.homeHeader))
                logger.Info("  Successfully reached 'UIMN Home' page.");
            else
                logger.Warn("Home page header not found.");

            // Click 'Applicants'
            WebActions.Click(UIMNHome.applicants);



            Thread.Sleep(5000);
            WebActions.CloseBrowser();
        }
    }
}
