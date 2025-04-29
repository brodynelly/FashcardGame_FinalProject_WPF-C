using System.Windows;

namespace FashcardGame_FinalProject_WPF_C_.views
{
    public partial class AddClassDialog : Window
    {
        public string ClassName { get; private set; }
        public string Description { get; private set; } // You might want to collect a description as well
        public bool IsAdded { get; private set; } = false;

        public AddClassDialog()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ClassNameTextBox.Text))
            {
                ClassName = ClassNameTextBox.Text;
                Description = DescriptionTextBox.Text; // Get the description as well
                IsAdded = true;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please enter a class name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}