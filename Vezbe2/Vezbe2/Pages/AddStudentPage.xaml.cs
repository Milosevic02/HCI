using Notification.Wpf;
using System;
using System.Collections.Generic;
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

namespace Vezbe2.Pages
{
    /// <summary>
    /// Interaction logic for AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        public AddStudentPage()
        {
            InitializeComponent();
            NameTextBox.Text = "Input student name";
            NameTextBox.Foreground = Brushes.LightSlateGray;

            SurnameTextBox.Text = "Input student surname";
            SurnameTextBox.Foreground = Brushes.LightSlateGray;

            DepartmentComboBox.ItemsSource = Constants.departments;
        }

        private void CreateStudentButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private Student CreateFromFormData()
        {
            if (MaleRadioButton.IsChecked == true)
            {
                return new Student(NameTextBox.Text, SurnameTextBox.Text, 'M', DepartmentComboBox.SelectedValue.ToString());
            }
            else
            {
                return new Student(NameTextBox.Text, SurnameTextBox.Text, 'F', DepartmentComboBox.SelectedValue.ToString());
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void NameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Trim().Equals("Input student name"))
            {
                NameTextBox.Text = "";
                NameTextBox.Foreground = Brushes.Black;
            }
        }

        private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Trim().Equals(string.Empty))
            {
                NameTextBox.Text = "Input student name";
                NameTextBox.Foreground = Brushes.LightSlateGray;
            }
        }

        private void SurnameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SurnameTextBox.Text.Trim().Equals("Input student surname"))
            {
                SurnameTextBox.Text = "";
                SurnameTextBox.Foreground = Brushes.Black;
            }
        }

        private void SurnameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SurnameTextBox.Text.Trim().Equals(string.Empty))
            {
                SurnameTextBox.Text = "Input student surname";
                SurnameTextBox.Foreground = Brushes.LightSlateGray;
            }
        }
    }
}
