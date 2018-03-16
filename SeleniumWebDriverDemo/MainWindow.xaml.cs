// App.xaml.cs

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

            WebAccess wa = new WebAccess();

            // Run Google demo
            wa.GoogleDemo();
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
        /// Close program ('About' menu item event handler)
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
