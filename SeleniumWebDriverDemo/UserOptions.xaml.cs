// UserOptions.xaml.cs

using System;
using System.Windows;
using System.ComponentModel;
using System.Collections.Generic;
using NLog;

namespace SeleniumWebDriverDemo
{
    /// <summary>
    /// Interaction logic for UserOptions.xaml
    /// </summary>
    public partial class UserOptions : Window, INotifyPropertyChanged
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private string _browser;
        private string _uiUserName;
        private string _uiPassword;

        public string Browser { get { return _browser; } set { _browser = value; OnPropertyChanged("Browser"); } }
        public string UIUserName { get { return _uiUserName; } set { _uiUserName = value; OnPropertyChanged("UIUserName"); } }
        public string UIPassword { get { return _uiPassword; } set { _uiPassword = value; OnPropertyChanged("UIPassword"); } }

        public List<string> Browsers { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// c'tor
        /// </summary>
        public UserOptions(string browser = "", string uiUserName = "", string uiPassword = "")
        {
            _browser = browser;
            _uiUserName = uiUserName;
            _uiPassword = uiPassword;

            string[] browsers = { "Default", "Firefox", "Chrome", "IE", "Edge", "Other" };
            Browsers = new List<string>(browsers);

            if (!Browsers.Contains(Browser))
            {
                logger.Warn(string.Format("Unrecognized browser '{0}'! Using 'Default' instead.", Browser));
                Browser = browsers[0];
            }

            InitializeComponent();
            this.DataContext = this;
            
        }


        /// <summary>
        /// Save button handler
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            return;
        }


        /// <summary>
        /// Support for INotifyPropertyChanged interface implementation
        /// </summary>
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}
