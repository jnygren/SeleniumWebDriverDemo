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
        //public static By BtnEmpLogin = By.Id("login-text");
        public static By BtnEmpLogin = By.XPath("//a[text()='EMPLOYEE LOG IN']");

        public static By hdrLogin = By.Id("Login");

        public static By titleMembers = By.XPath("/html/head/title[contains(text(), 'Members')]");
        //public static By titleMembers = By.XPath("/html/title");

        // Results page
        public static By H2Tracking = By.XPath("//h2[contains(text(), 'Tracking')]");
        public static By InpStressReduction = By.Id("42737|35-text");

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


    public class UIMNLogin
    {
        public static string title = "Applicant login";
        public static By sectionHeader = By.XPath("//td[contains(text(), 'Unemployment Insurance Benefits System')]");

        //public static By x1 = By.XPath("//table/tbody/tr/td/strong[contains(text(), 'Existing Applicants')]/../../.."); // tbody
        //public static By userId = By.Id("userId");
        public static By userId = By.XPath("//table/tbody/tr/td/strong[contains(text(), 'Existing Applicants')]/../../..//input[@Id='userId']");
        public static By password = By.XPath("//table/tbody/tr/td/strong[contains(text(), 'Existing Applicants')]/../../..//input[@Id='password']");
        public static By btnLogin = By.XPath("//table/tbody/tr/td/strong[contains(text(), 'Existing Applicants')]/../../..//input[@name='action.login.login.null']");

    }


}
