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
    }
}
