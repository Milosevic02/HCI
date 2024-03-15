using System.Windows;
using System.Windows.Media;
using Vezba1_2;

namespace Vezba1_2WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
            Student newStudent = CreateFromFormData();

            StudentInfoWindow newWindow = new StudentInfoWindow(newStudent);
            newWindow.ShowDialog();
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NameTextBox_GotFocus(object sender,RoutedEventArgs e)
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
