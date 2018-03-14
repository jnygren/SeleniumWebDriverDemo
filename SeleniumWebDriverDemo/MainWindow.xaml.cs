﻿// App.xaml.cs

using System.Windows;

namespace SeleniumWebDriverDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// c'tor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Close program ('Exit' menu item event handler)
        /// </summary>
        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        /// <summary>
        /// Close program ('Exit' menu item event handler)
        /// </summary>
        private void HelpAbout_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Owner = this;
            about.ShowInTaskbar = false;
            about.ShowDialog();
        }

    }
}
