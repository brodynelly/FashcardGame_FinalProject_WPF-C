using System.Windows.Controls;
using System.Windows.Navigation; // You might not strictly need this import for 'Loaded'
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
            if (NavigationService.Content == this && NavigationService.CurrentSource != null)
            {
                if (NavigationService.CurrentSource.OriginalString.Contains("ClassesPage") && NavigationService.BackStack.Count > 0)
                {
                    JournalEntry previousEntry = NavigationService.BackStack.Last();
                    if (previousEntry?.ExtraData is Student navigatedStudent)
                    {
                        if (DataContext is ClassesPageViewModel viewModel)
                        {
                            viewModel.CurrentStudent = navigatedStudent;
                        }
                        else
                        {
                            DataContext = new ClassesPageViewModel { CurrentStudent = navigatedStudent };
                        }
                    }
                }
            }
            else if (NavigationService.Content == this && NavigationService.ForwardStack.Count > 0)
            {
                JournalEntry forwardEntry = NavigationService.ForwardStack.Last();
                if (forwardEntry?.ExtraData is Student navigatedStudent)
                {
                    if (DataContext is ClassesPageViewModel viewModel)
                    {
                        viewModel.CurrentStudent = navigatedStudent;
                    }
                    else
                    {
                        DataContext = new ClassesPageViewModel { CurrentStudent = navigatedStudent };
                    }
                }
            }
            else if (Window.GetWindow(this)?.DataContext is MainViewModel mainWindowViewModel && mainWindowViewModel.CurrentPageViewModel is StudentConfigViewModel configViewModel && configViewModel.StudentConfig != null && this.DataContext is ClassesPageViewModel classesViewModel && classesViewModel.CurrentStudent == null)
            {
                classesViewModel.CurrentStudent = configViewModel.StudentConfig;
            }
            else if (Application.Current.MainWindow?.DataContext is MainViewModel mainVM && mainVM.CurrentPageViewModel is StudentConfigViewModel scVM && this.DataContext is ClassesPageViewModel cpVM && cpVM.CurrentStudent == null && scVM.StudentConfig != null)
            {
                cpVM.CurrentStudent = scVM.StudentConfig;
            }
        }
    }
}