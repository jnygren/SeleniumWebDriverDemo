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
            "Demonstrates (almost) everything I know about Selenium WebDriver.\r\n\r\n" +
            "\tToDo: \r\n" +
            "Add Scroll bars on 'About' box.\r\n" +
            "Add IE browser support.\r\n" +
            "Implement 'Default' browser detection.\r\n" +
            "Add 'Help'.\r\n" +
            "Add installer (Setup) project.\r\n" +
            "Add program icon.\r\n" +
            " \r\n" +
            "DONE - Add NLog logging. \r\n" +
            "DONE - Add Webdriver \r\n" +
            "DONE - Implement 'Display Logfile' feature.\r\n" +
            "DONE - Implement 'Request UI Benefits'. \r\n" +
            "DONE - Add config from App.config. \r\n" +
            "DONE - Add browser select. \r\n" +
            "DONE - Implement 'Save options' feature.\r\n" +
            "DONE - Fix bug preventing UI Login with Chrome.\r\n" +
            "DONE - Implement 'Print Screen' for confirmation page.\r\n" +
            " \r\n" +
            " \r\n" +
            "If you get the error \"Could not resolve mscorlib for target framework '.NETFramework...\" \r\n" +
            "when trying to open 'Settings.settings', just rebuild your solution. \r\n" +
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
