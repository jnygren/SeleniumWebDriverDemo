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
            WebActions.EnterText(GoogleSearchPage.TxtSearchText, "");
            foreach (char key in searchString.ToCharArray())
            {
                WebActions.AppendText(GoogleSearchPage.TxtSearchText, "" + key, 300);
            }
            Thread.Sleep(2000);
            WebActions.AppendText(GoogleSearchPage.TxtSearchText, ENTER, 100);
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
            WebActions.EnterText(UIMNLogin.userId, userSSN);
            WebActions.Click(UIMNLogin.password);
            WebActions.EnterText(UIMNLogin.password, password);
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
    }
}
