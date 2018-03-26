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
        //  *****  THIS IS EXAMPLE CODE FROM 'BADGE' PROJECT  *****


        // Search page
        public static By TxtSearchText = By.Id("lst-ib");
        /*
         * <input class="gsfi" id="lst-ib" name="q" title="Search" value="" 
        aria-label="Search" 
        url(&quot;data:image/gif;base64,...&quot;) type="text">

        //*[@id="lst-ib"]


         */

#if false

        public static By hdrWelcome = By.XPath("//div[@class='welcome-header']/h1[contains(text(), 'WELCOME TO')]");
        //public static By BtnEmpLogin = By.Id("login-text");
        public static By BtnEmpLogin = By.XPath("//a[text()='EMPLOYEE LOG IN']");
        //public static By BtnSpouseLogin = By.Id("spouse-text");
        public static By BtnSpouseLogin = By.XPath("//a[text()='SPOUSE LOG IN']");

        public static By hdrLogin = By.Id("Login");
        public static By TxtUsername = By.Id("username");
        public static By TxtPassword = By.Id("passwd");
        public static By BtnLogin = By.Id("login-btn");

        public static By titleMembers = By.XPath("/html/head/title[contains(text(), 'Members')]");
        //public static By titleMembers = By.XPath("/html/title");

        // Results page
        public static By H2Tracking = By.XPath("//h2[contains(text(), 'Tracking')]");
        public static By InpStressReduction = By.Id("42737|35-text");
        public static By BtnReset = By.Id("tracker-reset");
        public static By BtnSave = By.Id("tracker-submit");

        // Header
        public static By LinkTrack = By.XPath("//li[@id='nav_members_track']/a");
        public static By DDUserLinks = By.Id("user-links-trigger");

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


}
