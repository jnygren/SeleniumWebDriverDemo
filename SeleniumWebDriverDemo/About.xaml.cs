// About.xaml.cs

using System;
using System.Windows;
using System.Reflection;

namespace SeleniumWebDriverDemo
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        private string aboutText = 
            "\tSelenium WebDriver Demo\r\n" +
            "Demonstrates everything I know about Selenium WebDriver.\r\n\r\n" +
            "\tToDo: \r\n" +
            "Add config from App.config. \r\n" +
            "Add browser select. \r\n" +
            "Implement 'Save options' feature.\r\n" +
            "Add installer (Setup) project.\r\n" +
            "Add program icon.\r\n" +
            " \r\n" +
            "DONE - Add NLog logging. \r\n" +
            "DONE - Add Webdriver \r\n" +
            "DONE - Implement 'Display Logfile' feature.\r\n" +
            " \r\n" +
            " \r\n";
        public string AssemblyTitle { get { return Assembly.GetExecutingAssembly().GetName().Name; } }
        public string AssemblyVersion { get { return string.Format("Version: {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString()); } }
        public string AboutText { get { return aboutText; } }


        public About()
        {
            InitializeComponent();

            DataContext = this;
        }


    }
}
