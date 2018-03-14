// App.xaml.cs

using System.Windows;
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
            logger.Debug("---  End of Program.  ---\n");
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
