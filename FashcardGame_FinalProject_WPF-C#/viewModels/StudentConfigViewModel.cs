using FashcardGame_FinalProject_WPF_C_.views;
using System.Windows.Input;
using System.Windows;

namespace FashcardGame_FinalProject_WPF_C_.viewModels
{
    public class StudentConfigViewModel : BaseViewModel
    {
        private Game.Student _student;
        private bool _studentExists = false;
        private string _studentName;

        public string StudentName
        {
            get { return _studentName; }
            set
            {
                if (_studentName != value)
                {
                    _studentName = value;
                    OnPropertyChanged(nameof(StudentName));
                }
            }
        }

        public Game.Student StudentConfig
        {
            get { return _student; }
            set
            {
                if (_student != value)
                {
                    _student = value;
                    OnPropertyChanged(nameof(StudentConfig));
                }
            }
        }
        public bool StudentExists
        {
            get { return _studentExists; }
            set
            {
                if (_studentExists != value)
                {
                    _studentExists = value;
                    OnPropertyChanged(nameof(StudentExists));
                }
            }
        }
        public ICommand SaveStudentConfigCommand { get; }

        public StudentConfigViewModel()
        {
            SaveStudentConfigCommand = new RelayCommand(SaveStudentConfig);
            _student = new Game.Student();
            _studentName = ""; // Initialize _studentName
        }

        private void SaveStudentConfig()
        {
            Console.WriteLine($"Saving student configuration for {StudentName}");

            if (string.IsNullOrWhiteSpace(StudentName))
            {
                MessageBox.Show("Please enter a valid student name.");
                return;
            }
            // Create a new student object with the provided name
            _student.name = StudentName;
            StudentExists = true;
            NavigateToClassesPage(_student);
        }

        private void NavigateToClassesPage(Game.Student student)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow?.MainFrame != null)
            {
                var classesPage = new ClassesPage();
                classesPage.DataContext = new ClassesPageViewModel { CurrentStudent = student };
                mainWindow.MainFrame.Navigate(classesPage);
            }
        }
    }
}