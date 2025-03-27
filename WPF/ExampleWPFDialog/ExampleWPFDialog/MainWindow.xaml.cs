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

namespace ExampleWPFDialog;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        while (!OpenLoginWindow())
        { 
            MessageBox.Show("Erreur de connexion, veuillez réessayer");
        }
        

    }

    private static Boolean OpenLoginWindow()
    {
        var loginWindow = new LoginWindow();
        var result = loginWindow.ShowDialog();
        if (result == true)
        {
            MessageBox.Show("Connecté avec succès!");
            return true;
        }
        else
        {
            return false;
        }
    }
}