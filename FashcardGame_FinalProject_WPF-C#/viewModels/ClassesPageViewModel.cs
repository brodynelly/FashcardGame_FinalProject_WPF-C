using System.Collections.ObjectModel;
using System.Windows.Input;
using Game; // Ensure you have a reference to your "Game" project
using FashcardGame_FinalProject_WPF_C_.views;
using System.Windows; // For Application.Current

namespace FashcardGame_FinalProject_WPF_C_.viewModels
{
    public class ClassesPageViewModel : BaseViewModel
    {
        private Student _currentStudent = new Student("Default Student");
        public Student CurrentStudent
        {
            get { return _currentStudent; }
            set
            {
                _currentStudent = value;
                OnPropertyChanged(nameof(CurrentStudent));
                OnPropertyChanged(nameof(StudentName)); // Notify UI when CurrentStudent changes
                UpdateClassesList(); // Update the displayed list when the student changes
            }
        }

        private ObservableCollection<Course> _classesList;
        public ObservableCollection<Course> ClassesList
        {
            get { return _classesList; }
            set
            {
                _classesList = value;
                OnPropertyChanged(nameof(ClassesList));
            }
        }

        // Public property to expose the student's name for binding
        public string StudentName
        {
            get { return _currentStudent?.name; }
        }

        public ICommand AddClassCommand { get; }

        public ClassesPageViewModel()
        {
            // Initialize with a default student to avoid null exceptions
            CurrentStudent = new Student("Default Student");

            // Initialize the Add Class command
            AddClassCommand = new RelayCommand(OpenAddClassDialog);

            // Initialize the ClassesList based on the current student's courses
            UpdateClassesList();
        }

        private void OpenAddClassDialog()
        {
            var addClassDialog = new AddClassDialog();
            addClassDialog.Owner = Application.Current.MainWindow;

            if (addClassDialog.ShowDialog() == true)
            {
                string newClassName = addClassDialog.ClassName;

                if (!string.IsNullOrEmpty(newClassName))
                {
                    // Use the Student's method to add a new course
                    CurrentStudent.AddNewCourse(newClassName);
                    // Update the ObservableCollection to reflect the change
                    UpdateClassesList();
                }
            }
        }

        private void UpdateClassesList()
        {
            ClassesList = new ObservableCollection<Course>(CurrentStudent?.myCourses ?? new System.Collections.Generic.List<Course>());
        }
    }
}