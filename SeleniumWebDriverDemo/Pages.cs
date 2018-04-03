using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumWebDriverDemo
{
    class Pages
    {
    }


    public class GoogleSearchPage
    {
        // Search page
        public static By TxtSearchText = By.Id("lst-ib");


        //  *****  THIS IS EXAMPLE CODE FROM 'BADGE' PROJECT  *****

#if false

        public static By hdrWelcome = By.XPath("//div[@class='welcome-header']/h1[contains(text(), 'WELCOME TO')]");

        public static By hdrLogin = By.Id("Login");

        public static By titleMembers = By.XPath("/html/head/title[contains(text(), 'Members')]");
        //public static By titleMembers = By.XPath("/html/title");

        // Header
        public static By LinkTrack = By.XPath("//li[@id='nav_members_track']/a");

        // Dropdown
        public static By LinkLogout = By.XPath("//a[@href='/logout/']");

#endif

    }


    public class UIMNHome
    {
        public static string title = "index / Unemployment Insurance Minnesota";
        public static By homeHeader = By.XPath("//h1[contains(text(), 'Welcome to the Minnesota Unemployment Insurance')]");
        public static By applicants = By.XPath("//a[contains(text(), 'Applicants')]");

    }


    public class UIMNApplicants
    {
        public static string title = "Applicants - Unemployment Insurance Minnesota";
        public static By applicantsHeader = By.XPath("//h1[contains(text(), 'Welcome Applicants!')]");
        public static By request = By.XPath("//a[contains(text(), 'Request a Benefit Payment')]");

    }


    public class UIMNRestricted
    {
        public static string title = "Access Restricted";
        public static By restrictedHeader = By.XPath("//strong[contains(text(), 'The Unemployment Benefits System is currently not available.')]");
    }


    public class UIMNLogin
    {
        public static string title = "Applicant login";
        public static By sectionHeader = By.XPath("//td[contains(text(), 'Unemployment Insurance Benefits System')]");

        //public static By userId = By.Id("userId");    // There are 2 elements with this Id.
        public static By userId = By.XPath("//table/tbody/tr/td/strong[contains(text(), 'Existing Applicants')]/../../..//input[@Id='userId']");
        public static By password = By.XPath("//table/tbody/tr/td/strong[contains(text(), 'Existing Applicants')]/../../..//input[@Id='password']");
        public static By btnLogin = By.XPath("//table/tbody/tr/td/strong[contains(text(), 'Existing Applicants')]/../../..//input[@name='action.login.login.null']");

        public static By invalidEntry = By.XPath("//li[contains(text(), 'Invalid entry')]");

    }


    public class UIMNBenAcct
    {
        public static string title = "State Application";
        public static By msgsImportantHeader = By.XPath("//td[contains(text(), 'Important Messages')]");

        public static By msgsOtherHeader = By.XPath("//td[contains(text(), 'Other Messages')]");
        public static By haveUnrequested = By.XPath("//td[contains(text(), 'You may request benefit payments for the following weeks')]");
        public static By unrequestedWeek = By.XPath("//td[contains(text(), 'weeks that have not been requested')]//li");

        public static By sectBAHomeHeader = By.XPath("//td[contains(text(), 'My Benefit Account Home')]");
        public static By benefitsEstimate = By.XPath("//a[contains(text(), 'Future Benefits Estimate')]");
        public static By requestPayment = By.XPath("//a[contains(text(), 'Request Benefit Payment')]");
        public static By reemploymentAct = By.XPath("//a[contains(text(), 'Reemployment Activities')]");
        public static By maintainAccount = By.XPath("//a[contains(text(), 'View and Maintain My Account')]");

    }


    public class UIMNRequestPayHome
    {
        public static By sectRequestPayHomeHeader = By.XPath("//td[contains(text(), 'Request Payment Home')]");
        public static By proceedRequest = By.Name("action.requestPayment.proceedFromPreliminaryToAddressConfirm.null");

    }


    public class UIMNAddrVerify
    {
        public static By sectAddressVerifyHeader = By.XPath("//td[contains(text(), 'Address Verification')]");
        public static By hasNotChanged = By.Name("action.requestPayment.confirmFromAddressConfirmToInitialQuestions.null");

    }


    public class UIMNInitialQs
    {
        public static By sectInitialQuestionsHeader = By.XPath("//td[contains(text(), 'Initial Questions')]");

        //public static By workYes = By.XPath("//input[@id='requestPayment.requestpayment.regularInitialQuestionsTemplateResponse.didYouWork.value'][@value='Y']");
        public static By workNo = By.XPath("//input[@id='requestPayment.requestpayment.regularInitialQuestionsTemplateResponse.didYouWork.value'][@value='N']");
        public static By incomeNo = By.XPath("//input[@id='requestPayment.requestpayment.regularInitialQuestionsTemplateResponse.otherIncome.value'][@value='N']");
        public static By refuseNo = By.XPath("//input[@id='requestPayment.requestpayment.regularInitialQuestionsTemplateResponse.employmentOffer.value'][@value='N']");
        public static By quitNo = By.XPath("//input[@id='requestPayment.requestpayment.regularInitialQuestionsTemplateResponse.quit.value'][@value='N']");
        public static By dischargedNo = By.XPath("//input[@id='requestPayment.requestpayment.regularInitialQuestionsTemplateResponse.discharged.value'][@value='N']");
        public static By availableYes = By.XPath("//input[@id='requestPayment.requestpayment.regularInitialQuestionsTemplateResponse.availableForWork.value'][@value='Y']");
        public static By lookingYes = By.XPath("//input[@id='requestPayment.requestpayment.regularInitialQuestionsTemplateResponse.lookedForWork.value'][@value='Y']");

        public static By btnNext = By.Name("action.requestPayment.nextFromInitialQuestionsToDecideWorked.null");

    }


    public class UIMNActivityRpt
    {
        public static By sectActivityReportingHeader = By.XPath("//form[@name='RequestPaymentForm']/p");
        //public static By sectActivityReportingHeader = By.XPath("//p[contains(text(), 'Job Search Activity Reporting')]");    // This doesn't work.
        public static By btnNext = By.Name("action.requestPayment.nextFromWorkSearchPlanReportingToDecideFactFindingForFRMW.null");

    }


    public class UIMNRequestSummary
    {
        public static By sectRequestSummaryHeader = By.XPath("//td[contains(text(), 'Summary')]");

        //public static By requestForm = By.XPath("//form[@name='RequestPaymentForm']");
        //public static By printTable = By.XPath("//form[@name='RequestPaymentForm']/table[3]");
        public static By lnkPrint = By.XPath("//form[@name='RequestPaymentForm']/table[3]//a");

        //public static By imgAny = By.XPath("//img");
        //public static By imgClose = By.XPath("//img[@alt='Close']");
        //public static By imgClose = By.XPath("//img[contains(@alt,'Close')]");
        //public static By btnx = By.XPath("//a/img/..");
        //public static By btnPrintClose = By.XPath("//a/img[contains(@src,'b_close.gif')]/..");
        //public static By btnPrintClose = By.XPath("//*[@*='javascript:window.close()']");
        public static By btnSubmit = By.Name("action.requestPayment.confirmFromSummaryToEnd.null");

    }


    public class UIMNRequestConfirm
    {
        public static By sectRequestConfirmationHeader = By.XPath("//td[contains(text(), 'Request for Benefit Payment Confirmation Page')]");
        public static By lnkPrint = By.XPath("//form[@name='RequestPaymentForm']/table[4]//a");
        // These are untested
        //public static By lnkReturn = By.LinkText("Return to Account Home Page");
        //public static By lnkReturn = By.XPath("//a[@href = '/ui_applicant/applicant/home.do']";
        public static By lnkReturn = By.XPath("//form[@name='RequestPaymentForm']/table[3]//a");

    }


    public class UIMNMaster
    {
        public static By logoff = By.XPath("//a[contains(text(), 'Log Off')]");

    }


}
