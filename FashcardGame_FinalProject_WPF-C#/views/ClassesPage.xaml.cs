using System.Windows.Controls;
using FashcardGame_FinalProject_WPF_C_.viewModels;
using Game; // Make sure you have this using statement
using System.Windows; // For RoutedEventArgs

namespace FashcardGame_FinalProject_WPF_C_.views
{
    /// <summary>
    /// Interaction logic for ClassesPage.xaml
    /// </summary>
    public partial class ClassesPage : Page
    {
        public ClassesPage()
        {
            InitializeComponent();
            this.Loaded += ClassesPage_Loaded; // Subscribe to the Loaded event
        }

        private void ClassesPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Accessing the MainViewModel and StudentConfigViewModel through the Window's DataContext
            if (Window.GetWindow(this)?.DataContext is MainViewModel mainWindowViewModel &&
                mainWindowViewModel.CurrentPageViewModel is StudentConfigViewModel configViewModel &&
                configViewModel.StudentConfig != null &&
                DataContext is ClassesPageViewModel classesViewModel &&
                classesViewModel.CurrentStudent == null)
            {
                classesViewModel.CurrentStudent = configViewModel.StudentConfig;
            }
            else if (Application.Current.MainWindow?.DataContext is MainViewModel mainVM &&
                     mainVM.CurrentPageViewModel is StudentConfigViewModel scVM &&
                     DataContext is ClassesPageViewModel cpVM &&
                     cpVM.CurrentStudent == null &&
                     scVM.StudentConfig != null)
            {
                cpVM.CurrentStudent = scVM.StudentConfig;
            }
        }
    }
}