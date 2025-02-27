using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ExemplObservableCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Names { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Names = new ObservableCollection<string>();
            Names.Add("Alice");
            Names.Add("Bob");
            Names.Add("Charlie");
            DataContext = this;
        }

        private void AddNameButton_Click(object sender, RoutedEventArgs e)
        {
            Names.Add("New name");
        }
    }
}
