using Notification.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DataTablePage.xaml
    /// </summary>
    public partial class DataTablePage : Page
    {
        public ObservableCollection<Student> Students { get; set; }

        MainWindow mainWindow;

        public DataTablePage()
        {
            InitializeComponent();

            mainWindow = (MainWindow)Application.Current.MainWindow;

            Students = mainWindow.Students;

            DataContext = this;
        }

        private void RemoveStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if(Students.Count > 0)
            {
                if(StudentsDataGrid.SelectedIndex != -1)
                {
                    Students.RemoveAt(StudentsDataGrid.SelectedIndex);
                    mainWindow.ShowToastNotification(new ToastNotification("Success", "Student removed from the Data Table", NotificationType.Success));

                }
                else
                {
                    mainWindow.ShowToastNotification(new ToastNotification("Error", "A student must be selected first!", NotificationType.Error));
                }
            }
            else
            {
                mainWindow.ShowToastNotification(new ToastNotification("Error","Cannot delete from empty table!",NotificationType.Error));
            }

        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/AddStudentPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
