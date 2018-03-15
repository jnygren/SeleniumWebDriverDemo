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
            //MessageBox.Show("x");
            WebActions.OpenUrl(GoogleURL);
            // wait
            Thread.Sleep(10000);
            WebActions.CloseBrowser();
        }
    }
}
