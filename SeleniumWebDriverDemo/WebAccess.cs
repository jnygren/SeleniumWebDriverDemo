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
            Thread.Sleep(1000);
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
            Thread.Sleep(1000);
            #endregion

            // ==============================           UIMN Login page          ==============================
            #region Login page

            // Check for page title
            pageTitle = WebActions.GetTitle();
            if (pageTitle.Contains(UIMNLogin.title))
                logger.Info(string.Format("Found page title \"{0}\".", pageTitle));
            else if (pageTitle.Contains(UIMNRestricted.title))
            {
                string msg = "The Unemployment Benefits System is currently not available.\r\n" +
                                "Normal hours of operation are between 6 a.m.and 6 p.m.Central Time, Monday through Friday.\r\n\r\n" +
                                "The 'UI Benefit Request' demo will now end.";

                Thread.Sleep(3000);
                WebActions.CloseBrowser();
                MessageBox.Show(msg, UIMNRestricted.title);
                logger.Warn(msg);
                return;
            }
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
            Thread.Sleep(1000);
            #endregion

            // ==============================     UIMN Benefit Account page      ==============================
            #region Benefit Account page

            //// Check for page title
            //pageTitle = WebActions.GetTitle();
            //if (pageTitle.Contains(UIMNBenAcct.title))
            //    logger.Info(string.Format("Found page title \"{0}\".", pageTitle));
            //else
            //    logger.Error(string.Format("Wrong page Title. Expected {0}, found {1}", UIMNBenAcct.title, pageTitle));

            // Confirm correct page
            if (WebActions.WaitForTheElement(UIMNBenAcct.sectBAHomeHeader, 10))
                logger.Info("  Successfully reached 'UIMN Benefit Account' page.");
            else if (WebActions.WaitForTheElement(UIMNLogin.invalidEntry))
            {
                string msg = "The username (SSN) and/or password you entered are not valid.\r\n" +
                                "Use valid credentials and run the demo again.\r\n\r\n" +
                                "The 'UI Benefit Request' demo will now end.";

                Thread.Sleep(3000);
                WebActions.CloseBrowser();
                MessageBox.Show(msg, "Invalid Entry");
                logger.Warn(msg);
                return;
            }
            else
                logger.Warn("Benefit Account page header not found.");

            // Confirm that there are weeks for which benefit payment may be requested
            if (WebActions.WaitForTheElement(UIMNBenAcct.haveUnrequested) &&
                WebActions.WaitForTheElement(UIMNBenAcct.requestPayment))
            {
                string unrequestedWeek = WebActions.GetText(UIMNBenAcct.unrequestedWeek);
                logger.Info("  Attempting to request payment for " + unrequestedWeek + ".");

                // Click 'Request a Benefit Payment'
                WebActions.Click(UIMNBenAcct.requestPayment);
                Thread.Sleep(2000);
            }
            else
            {
                logger.Warn("There appears to be no weeks to claim.");
                string msg = "It appears you have no weeks for which you may claim benefit payments.\r\n\r\n" +
                                "The 'UI Benefit Request' demo has logged out, and will now end.";

                Thread.Sleep(2000);
                WebActions.Click(UIMNMaster.logoff);
                Thread.Sleep(2000);
                WebActions.CloseBrowser();
                MessageBox.Show(msg, UIMNBenAcct.title);
                logger.Warn(msg);
                return;
            }

            #endregion

            // ==============================   UIMN Request Payment Home page   ==============================
            #region Request Payment Home page
            // Confirm correct page
            if (WebActions.WaitForTheElement(UIMNRequestPayHome.sectRequestPayHomeHeader))
                logger.Info("  Successfully reached 'UIMN Request Payment Home' page.");
            else
                logger.Warn("Request Payment Home page header not found.");

            // Click 'Proceed with Request Payment'
            WebActions.Click(UIMNRequestPayHome.proceedRequest);
            Thread.Sleep(2000);
            #endregion

            // ==============================   UIMN Address Verification page   ==============================
            #region Address Verification page
            // Confirm correct page
            if (WebActions.WaitForTheElement(UIMNAddrVerify.sectAddressVerifyHeader))
                logger.Info("  Successfully reached 'UIMN Address Verification' page.");
            else
                logger.Warn("Address Verification page header not found.");

            // Click 'My Info Has Not Changed'
            WebActions.Click(UIMNAddrVerify.hasNotChanged);
            Thread.Sleep(2000);
            #endregion

            // ==============================     UIMN Initial Questions page    ==============================
            #region Initial Questions page
            // Confirm correct page
            if (WebActions.WaitForTheElement(UIMNInitialQs.sectInitialQuestionsHeader))
                logger.Info("  Successfully reached 'UIMN Initial Questions' page.");
            else
                logger.Warn("Initial Questions page header not found.");

            // Answer work search questions
            WebActions.CheckCheckbox(UIMNInitialQs.workNo);
            WebActions.CheckCheckbox(UIMNInitialQs.incomeNo);
            WebActions.CheckCheckbox(UIMNInitialQs.refuseNo);
            WebActions.CheckCheckbox(UIMNInitialQs.quitNo);
            WebActions.CheckCheckbox(UIMNInitialQs.dischargedNo);
            WebActions.CheckCheckbox(UIMNInitialQs.availableYes);
            WebActions.CheckCheckbox(UIMNInitialQs.lookingYes);
            logger.Info("Initial eligibility questions answered.");
            Thread.Sleep(1000);

            // Click 'Next'
            WebActions.Click(UIMNInitialQs.btnNext);
            Thread.Sleep(2000);
            #endregion

            // ==============================    UIMN Job Search Plan Rpt page   ==============================
            #region Job Search Plan Reporting page
            // Confirm correct page
            if (WebActions.WaitForTheElement(UIMNActivityRpt.sectActivityReportingHeader))
                logger.Info("  Successfully reached 'UIMN Job Search Activity Reporting' page.");
            else
                logger.Warn("Activity Reporting page header not found.");

            // Click 'Next' button
            WebActions.Click(UIMNActivityRpt.btnNext);
            Thread.Sleep(2000);
            #endregion

            // ==============================      UIMN Request Summary page     ==============================
            #region Request Summary page
            // Confirm correct page
            if (WebActions.WaitForTheElement(UIMNRequestSummary.sectRequestSummaryHeader))
                logger.Info("  Successfully reached 'UIMN Request Summary' page.");
            else
                logger.Warn("Request Summary page header not found.");

            // Print request summary
#if PRINT_SUMMARY
            //WebActions.ForDebug(UIMNRequestSummary.requestForm);
            //WebActions.ForDebug(UIMNRequestSummary.printTable);
            //WebActions.ForDebug(UIMNRequestSummary.lnkPrint);
            WebActions.Click(UIMNRequestSummary.lnkPrint);
            Thread.Sleep(5000);
            // Confirm correct page
            WebActions.ForDebug(UIMNRequestSummary.imgAny);
            //WebActions.ForDebug(UIMNRequestSummary.imgClose);
            //WebActions.ForDebug(UIMNRequestSummary.btnx);
            WebActions.ForDebug(UIMNRequestSummary.btnPrintClose);
            if (WebActions.WaitForTheElement(UIMNRequestSummary.btnPrintClose))
                logger.Info("  Successfully reached 'UIMN Request Summary Print' page.");
            else
                logger.Warn("Request Summary Print page 'Close' link not found.");
            WebActions.Click(UIMNRequestSummary.btnPrintClose);
            Thread.Sleep(2000);
#endif

            // Submit request for weekly benefit payment
            WebActions.Click(UIMNRequestSummary.btnSubmit);
            Thread.Sleep(2000);
            #endregion

            // ==============================   UIMN Request Confirmation page   ==============================
            #region Request Confirmation page
            // Confirm correct page
            if (WebActions.WaitForTheElement(UIMNRequestConfirm.sectRequestConfirmationHeader))
                logger.Info("  Successfully reached 'UIMN Request Confirmation' page.");
            else
                logger.Warn("Request Confirmation page header not found.");

            // Print a copy of the Request Confirmation
            //WebActions.Click(UIMNRequestConfirm.lnkReturn);

            // Return to Account Home Page
            WebActions.Click(UIMNRequestConfirm.lnkReturn);
            Thread.Sleep(2000);
            #endregion

            // Wait! Don't log off until you save confirmation page info.
            //WebActions.ForDebug(UIMNRequestSummary.lnkPrint);

            Thread.Sleep(2000);
            // Log off
            WebActions.Click(UIMNMaster.logoff);
            Thread.Sleep(5000);
            // Close
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
                WebActions.AppendText(by, "" + key, 100);
            }
            Thread.Sleep(1000);

            if (sendEnter)
                WebActions.AppendText(by, ENTER, 100);
        }


        #endregion
    }
}
