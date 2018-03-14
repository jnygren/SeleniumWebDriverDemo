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
            "Does stuff.\r\n\r\n" +
            "\tToDo: \r\n" +
            "Add NLog logging. \r\n" +
            "Add config from App.config. \r\n" +
            "Add Webdriver \r\n" +
            "Add browser select. \r\n" +
            " \r\n" +
            "Implement 'Save options' feature.\r\n" +
            "(NOT) DONE - Add installer (Setup) project.\r\n" +
            "DONE - Add program icon.\r\n" +
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
