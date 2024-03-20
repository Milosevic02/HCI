using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private bool _isDarkTheme;
        private Brush _defaultToolBarColor;

        public bool IsDarkTheme
        {
            get { return _isDarkTheme; }
            set
            {
                if (_isDarkTheme != value)
                {
                    _isDarkTheme = value;
                    OnPropertyChanged("IsDarkTheme");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            IsDarkTheme = false;
            _defaultToolBarColor = EditorToolBar.Background;

            FontFamilyComboBox.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            this.DataContext = this;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FontFamilyComboBox.SelectedItem != null && !EditorRichTextBox.Selection.IsEmpty)
            {
                EditorRichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, FontFamilyComboBox.SelectedItem);
            }

        }

        private void DarkThemeToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            IsDarkTheme = true;
            UIPath.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#262626");
            DarkThemeToggleButton.Background = Brushes.DarkGray;
            CloseButton.Background = Brushes.DarkGray;
            EditorToolBar.Background = Brushes.DarkGray;
        }

        private void DarkThemeToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void EditorRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object fontWeight = EditorRichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            BoldToggleButton.IsChecked = (fontWeight != DependencyProperty.UnsetValue) &&(fontWeight.Equals(FontWeights.Bold));

            object fontFamily = EditorRichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            FontFamilyComboBox.SelectedItem = fontFamily;
        }
    }
}
