﻿using Notification.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vezbe2.Helpers;
using Vezbe2.Model;
using Vezbe2.Pages;

namespace Vezbe2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotificationManager notificationManager;

        public ObservableCollection<Student> Students;

        public MainWindow()
        {
            InitializeComponent();

            notificationManager = new NotificationManager();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack(); 
            }
        }

        private void DataTablePageMenuItem_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage("DataTablePage");
        }

        private void AddStudentPageMenuItem_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage("AddStudentPage");
        }

        private void NavigateToPage(Page page)
        { 
            MainFrame.Navigate(page);
        }

        private void NavigateToPage(string pageName)
        {
            String pageUri = "Pages/" + pageName + ".xaml"; 
            MainFrame.Navigate(new Uri(pageUri, UriKind.RelativeOrAbsolute)); 
        }

        public void ShowToastNotification(ToastNotification toastNotification)
        {
            notificationManager.Show(toastNotification.Title, toastNotification.Message, toastNotification.Type, "WindowNotificationArea");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
