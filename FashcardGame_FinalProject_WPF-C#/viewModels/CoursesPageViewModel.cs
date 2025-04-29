using System.Windows.Input;

namespace FashcardGame_FinalProject_WPF_C_.viewModels
{
    internal class StudySets : BaseViewModel
    {
        // A property to represent a list of courses (you can replace this with your actual course data)
        private string _selectedCourse;
        public string SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                _selectedCourse = value;
                OnPropertyChanged(nameof(SelectedCourse)); // Notifies the UI when SelectedCourse changes
            }
        }

        // A list of courses that can be displayed or selected (example, replace with your actual list)
        public List<string> AvailableCourses { get; set; }

        // Command to start a course
        public ICommand StartCourseCommand { get; }

        // Constructor to initialize commands and data
        public StudySets()
        {
            // Initialize the command that will be executed when the button is clicked
            StartCourseCommand = new RelayCommand(StartCourse);

            // Example course data (replace with your actual course list or data)
            AvailableCourses = new List<string> { "Math 101", "Science 101", "History 101" };
        }

        // Logic for starting a course
        private void StartCourse()
        {
            if (!string.IsNullOrEmpty(SelectedCourse))
            {
                // Logic to start the course (you can add navigation or course-related actions here)
                // For now, just update the property to indicate the course started
                SelectedCourse = $"Starting {SelectedCourse}...";
            }
        }
    }
}
