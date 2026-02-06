using System;
using System.Collections.ObjectModel;
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

namespace MotorController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Motor> Motors { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Motors = new ObservableCollection<Motor>
            {
                new Motor { ID = 1, Speed = 28 },
                new Motor { ID = 2, Speed = -35 },
                new Motor { ID = 3, Speed = 42 }
            };

            // Set DataContext for binding
            DataContext = this;     
        }
    }
}