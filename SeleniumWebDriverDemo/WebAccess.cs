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
            string browser = Properties.Settings.Default.Browser;
            //logger.Info("In WebAccess() - browser = " + browser + ".");

            // Select the specified browser
            WebActions.SelectBrowser(browser);
        }


        /// <summary>
        /// Google Demo - Search on 'Selenium'
        /// </summary>
        public void GoogleDemo()
        {
            String searchString = "Selenium";

            WebActions.OpenUrl(GoogleURL);
            // wait
            Thread.Sleep(2000);

            // Check for page title
            string pageTitle = WebActions.GetTitle();
            if (pageTitle.Contains("Google"))
                logger.Info(string.Format("Found page title \"{0}\".", pageTitle));
            else
                logger.Error("Wrong page Title.");

            // Google Search Page
            if (WebActions.WaitForTheElement(GoogleSearchPage.TxtSearchText))
                logger.Info("  Successfully reached 'Google Search' page.");

            // Enter search string (slowly)
            DisplayEnterText(GoogleSearchPage.TxtSearchText, searchString, true);
            Thread.Sleep(2000);

            // Check for page title
            pageTitle = WebActions.GetTitle();
            if (pageTitle.Contains("Selenium - Google Search"))
                logger.Info(string.Format("Found page title \"{0}\".", pageTitle));
            else
                logger.Error("Wrong page Title.");

            Thread.Sleep(5000);
            WebActions.CloseBrowser();
        }


        /// <summary>
        /// Unemployment Insurance Request - Use WebDriver to make a payment request
        /// </summary>
        public void UIRequest()
        {
            String userSSN = "000000000";
            String password = "mmmmmmmm";

            logger.Info("In WebAccess.UIRequest().");

            // Go to UI website
            WebActions.OpenUrl(UIMN_URL);
            Thread.Sleep(2000);

            // ==============================           UIMN Home page           ==============================
            #region Home page

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
            Thread.Sleep(2000);
            #endregion

            // ==============================        UIMN Applicants page        ==============================
            #region Applicants page

            // Check for page title
            pageTitle = WebActions.GetTitle();
            if (pageTitle.Contains(UIMNApplicants.title))
                logger.Info(string.Format("Found page title \"{0}\".", pageTitle));
            else
                logger.Error(string.Format("Wrong page Title. Expected {0}, found {1}", UIMNApplicants.title, pageTitle));

            // Confirm correct page
            if (WebActions.WaitForTheElement(UIMNApplicants.applicantsHeader))
                logger.Info("  Successfully reached 'UIMN Applicants' page.");
            else
                logger.Warn("Applicants page header not found.");

            // Click 'Request a Benefit Payment'
            WebActions.Click(UIMNApplicants.request);
            Thread.Sleep(2000);
            #endregion

            // ==============================           UIMN Login page          ==============================
            #region Login page

            // Check for page title
            pageTitle = WebActions.GetTitle();
            if (pageTitle.Contains(UIMNLogin.title))
                logger.Info(string.Format("Found page title \"{0}\".", pageTitle));
            else
                logger.Error(string.Format("Wrong page Title. Expected {0}, found {1}", UIMNLogin.title, pageTitle));

            // Confirm correct page
            if (WebActions.WaitForTheElement(UIMNLogin.sectionHeader))
                logger.Info("  Successfully reached 'UIMN Login' page.");
            else
                logger.Warn("Login page header not found.");

            // Enter User Name (SSN) & Password
            WebActions.Click(UIMNLogin.userId);
            DisplayEnterText(UIMNLogin.userId, userSSN);
            WebActions.Click(UIMNLogin.password);
            DisplayEnterText(UIMNLogin.password, password);
            WebActions.Click(UIMNLogin.btnLogin);
            Thread.Sleep(2000);
            #endregion

            // ==============================           UIMN ____ page           ==============================
            #region ____ page
            #endregion

            // ==============================           UIMN ____ page           ==============================
            #region ____ page
            #endregion

            // ==============================           UIMN ____ page           ==============================
            #region ____ page
            #endregion


            //WebActions.ForDebug(UIMNLogin.userId);

            Thread.Sleep(5000);
            WebActions.CloseBrowser();
        }


        #region Helper Methods

        /// <summary>
        /// Display EnterText - Enter text into field one character at a time.
        /// </summary>
        /// <param name="by">Field to enter text to.</param>
        /// <param name="searchString">Text to enter.</param>
        /// <param name="sendEnter">If true, send 'Enter' after text string.</param>
        private static void DisplayEnterText(OpenQA.Selenium.By by, string searchString, bool sendEnter = false)
        {
            String ENTER = OpenQA.Selenium.Keys.Enter;

            WebActions.EnterText(by, "");
            foreach (char key in searchString.ToCharArray())
            {
                WebActions.AppendText(by, "" + key, 300);
            }
            Thread.Sleep(1000);

            if (sendEnter)
                WebActions.AppendText(by, ENTER, 100);
        }


        #endregion
    }
}
