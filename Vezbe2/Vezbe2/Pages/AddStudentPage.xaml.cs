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
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            if (ValidateFormData())
            {
                Student newStudent = CreateFromFormData();
                mainWindow.Students.Add(newStudent);

                mainWindow.ShowToastNotification(new ToastNotification("Success", "Student added to the Data Table", NotificationType.Success));

                this.NavigationService.Navigate(new Uri("Pages/DataTablePage.xaml", UriKind.RelativeOrAbsolute));

            }
            else
            {
                mainWindow.ShowToastNotification(new ToastNotification("Error", "Form fields are not correctly filled!", NotificationType.Error));

            }

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

        private bool ValidateFormData()
        {
            bool isValid = true;

            if(NameTextBox.Text.Trim().Equals(string.Empty) || NameTextBox.Text.Trim().Equals("Input student name")) {
                
                isValid = false;
                NameErrorLabel.Content = "Form field cannot be left empty";
                NameTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                NameErrorLabel.Content = string.Empty;
                NameTextBox.BorderBrush= Brushes.Green;
            }

            if (SurnameTextBox.Text.Trim().Equals(string.Empty) || SurnameTextBox.Text.Trim().Equals("Input student surname"))
            {
                isValid = false;
                SurnameErrorLabel.Content = "Form field cannot be left empty!";
                SurnameTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                SurnameErrorLabel.Content = string.Empty;
                SurnameTextBox.BorderBrush = Brushes.Gray;
            }

            if (MaleRadioButton.IsChecked == false && FemaleRadioButton.IsChecked == false)
            {
                isValid = false;
                GenderErrorLabel.Content = "An option must be chosen!";
            }
            else
            {
                GenderErrorLabel.Content = string.Empty;
            }

            if (DepartmentComboBox.SelectedItem == null)
            {
                isValid = false;
                DepartmentErrorLabel.Content = "An option must be chosen!";
                DepartmentComboBoxColorBorder.BorderThickness = new Thickness(1);
                DepartmentComboBoxColorBorder.BorderBrush = Brushes.Red;
            }
            else
            {
                DepartmentErrorLabel.Content = string.Empty;
                DepartmentComboBoxColorBorder.BorderBrush = Brushes.Gray;
            }

            return isValid;
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
