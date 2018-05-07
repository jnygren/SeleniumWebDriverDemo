// App.xaml.cs

using System;
using System.Windows;
using System.Diagnostics;
using NLog;

namespace SeleniumWebDriverDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// c'tor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Window Loaded event handler
        /// </summary>
        /// <remarks>
        ///    To add handlers like this, 
        ///    1. open .xaml and select <window> element. 
        ///    2. In Properties panel at right, click 'events', then double-click the event you want a handler for.
        /// </remarks>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logger.Debug("---  Program started.  ---");
        }


        /// <summary>
        /// Window Closed event handler
        /// </summary>
        private void Window_Closed(object sender, System.EventArgs e)
        {
            string msgEnd = "---  End of Program.  ---\r\n" +
                            "================================================================================\r\n";
            logger.Debug(msgEnd);
        }


        /// <summary>
        /// Google demo - Demonstrate using WebDriver to do a Google search.
        /// </summary>
        private void GoogleDemo_Click(object sender, RoutedEventArgs e)
        {
            logger.Info("In GoogleDemo_Click.");

            try
            {
                WebAccess wa = new WebAccess();

                // Run Google demo
                wa.GoogleDemo();
            }
            catch (Exception ex)
            {
                string exMessage = string.Format("Exception caught: {0}.", ex.Message);
                logger.Error(exMessage);

                this.Activate();
                MessageBox.Show(exMessage, "Error: Exception in GoogleDemo()");
            }
        }


        /// <summary>
        /// Unemployment Insurance Benefit Request - To practice test automation.
        /// </summary>
        private void UIRequest_Click(object sender, RoutedEventArgs e)
        {
            logger.Info("In UIRequest_Click.");

            try
            {
                WebAccess wa = new WebAccess();

                // Run Unemployment Insurance Request demo
                wa.UIRequest();
            }
            catch (Exception ex)
            {
                string exMessage = string.Format("Exception caught: {0}.", ex.Message);
                logger.Error(exMessage);

                this.Activate();
                MessageBox.Show(exMessage, "Error");
            }
        }


        /// <summary>
        /// Print-Screen demo - Demonstrate using WebDriver to do a screen print.
        /// </summary>
        private void PrintDemo_Click(object sender, RoutedEventArgs e)
        {
            logger.Info("In PrintDemo_Click.");

            try
            {
                WebAccess wa = new WebAccess();

                // Run PrintScreen demo
                wa.PrintDemo();
            }
            catch (Exception ex)
            {
                string exMessage = string.Format("Exception caught: {0}.", ex.Message);
                logger.Error(exMessage);

                this.Activate();
                MessageBox.Show(exMessage, "Error: Exception in PrintDemo()");
            }
        }


        /// <summary>
        /// 'File - View Log' menu item handler
        /// </summary>
        private void ViewLog_Click(object sender, RoutedEventArgs e)
        {
            logger.Info("In ViewLog_Click.");

            NLog.Targets.FileTarget fileTarget = (NLog.Targets.FileTarget)LogManager.Configuration.FindTargetByName("file");
            string logfile = fileTarget.FileName.Render(new LogEventInfo());
            Process.Start(logfile.Replace("\\/", "/"));     // Open logfile in default viewer
        }


        /// <summary>
        /// Close program ('Exit' menu item event handler)
        /// </summary>
        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        /// <summary>
        /// Options ('Options' menu item event handler)
        /// </summary>
        private void ToolsOptions_Click(object sender, RoutedEventArgs e)
        {
            logger.Info("Options menu displayed.");

            //string browser = Properties.Settings.Default.Browser;
            //UserOptions options = new SeleniumWebDriverDemo.UserOptions("One", "Two", "Three");
            UserOptions options = new UserOptions(Properties.Settings.Default.Browser, Properties.Settings.Default.Username, Properties.Settings.Default.Password);
            options.Owner = this;
            options.ShowInTaskbar = false;
            if ((bool)options.ShowDialog())
            {
                logger.Warn(String.Format("User options changed: Browser = {0}, User = {1}, PW = {2}.", options.Browser, options.UIUserName, options.UIPassword));

                Properties.Settings.Default.Browser = options.Browser;
                Properties.Settings.Default.Username = options.UIUserName;
                Properties.Settings.Default.Password = options.UIPassword;
                Properties.Settings.Default.Save();  // Set properties.
            }
        }


        /// <summary>
        /// About ('About' menu item event handler)
        /// </summary>
        private void HelpAbout_Click(object sender, RoutedEventArgs e)
        {
            logger.Info("About box displayed.");

            About about = new About();
            about.Owner = this;
            about.ShowInTaskbar = false;
            about.ShowDialog();
        }

    }
}
