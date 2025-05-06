using FashcardGame_FinalProject_WPF_C_.viewModels;
using System;
using System.Collections.Generic;
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

namespace FashcardGame_FinalProject_WPF_C_.views
{
    /// <summary>
    /// Interaction logic for StudentConfig.xaml
    /// </summary>
    public partial class StudentConfig : Page
    {
        public StudentConfig()
        {
            InitializeComponent();
            this.DataContext = new StudentConfigViewModel();   // Set the ViewModel for this page
        }
    }
}
