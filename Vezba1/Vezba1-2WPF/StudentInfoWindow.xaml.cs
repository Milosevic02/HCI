using System.Windows;
using Vezba1_2;

namespace Vezba1_2WPF
{
    /// <summary>
    /// Interaction logic for StudentInfoWindow.xaml
    /// </summary>
    public partial class StudentInfoWindow : Window
    {
        public StudentInfoWindow()
        {
            InitializeComponent();
        }

        public StudentInfoWindow(Student student)
        {
            InitializeComponent();

            StudentInfoLabel.Content += student.Name + " " + student.Surname;
            StudentInfoLabel.Content += "\nDepartment: " + student.Department;

            if (student.Gender == 'M')
            {
                StudentInfoLabel.Content += "\nGender: Male";
            }
            else
            {
                StudentInfoLabel.Content += "\nGender: Female";
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
