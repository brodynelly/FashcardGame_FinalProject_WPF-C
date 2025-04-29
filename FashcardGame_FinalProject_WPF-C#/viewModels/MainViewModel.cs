using FashcardGame_FinalProject_WPF_C_.views;
using System.Windows;
using System.Windows.Input;

namespace FashcardGame_FinalProject_WPF_C_.viewModels
{
    public class MainViewModel
    {
        private StudentConfigViewModel studentConfig;
        public ICommand NavigateToClassesCommand { get; }
        public ICommand NavigateToCoursesCommand { get; }
        public ICommand NavigateToFlashcardsCommand { get; }
        public ICommand NavigateToStudentCommand { get; }

        public MainViewModel()
        {
            studentConfig = new StudentConfigViewModel();
            NavigateToStudentCommand = new RelayCommand(NavigateToStudent);
            NavigateToClassesCommand = new RelayCommand(NavigateToClasses);
            NavigateToCoursesCommand = new RelayCommand(NavigateToCourses);
            NavigateToFlashcardsCommand = new RelayCommand(NavigateToFlashcards);

            // Check if student exists, otherwise navigate to StudentConfig
            if (!studentConfig.StudentExists)
            {
                NavigateToStudent();
            }
        }

        public void NavigateToStudent()
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new StudentConfig()); // Navigate to the StudentConfig page
            }
        }

        private void NavigateToClasses()
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.MainFrame.Navigate(new ClassesPage());
        }

        private void NavigateToCourses()
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.MainFrame.Navigate(new StudySetsPage());
        }

        private void NavigateToFlashcards()
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.MainFrame.Navigate(new FlashcardsPage());
        }
    }
}
