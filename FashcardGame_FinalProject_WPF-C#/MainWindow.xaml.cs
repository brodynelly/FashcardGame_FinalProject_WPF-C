using FashcardGame_FinalProject_WPF_C_.viewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using FashcardGame_FinalProject_WPF_C_.viewModels;
using System.Security.Cryptography.X509Certificates;

namespace FashcardGame_FinalProject_WPF_C_
{

        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new MainViewModel(); 
            }
        }

}
