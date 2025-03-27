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
using System.Windows.Shapes;
using System.Diagnostics;

namespace ExampleWPFDialog
{
    /// <summary>
    /// Logique d'interaction pour LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        // Ajout d'une variable pour permttre de réafficher la fenêtre de connexion en cas de mauvais credentials
        // Si c'est un dialog normal, on peut utiliser le DialogResult pour savoir si l'utilisateur a cliqué sur OK ou annuler
        private bool mustExit = true;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OnClickOK(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("OK clicked");
            
            var username = this.UserTextBox.Text;
            var password = this.PasswordTextBox.Password.ToString();
            if (username == "admin" && password == "admin")
            {
                this.mustExit = false;
                this.DialogResult = true;
            }
            else
            {
                this.mustExit = false;
                this.DialogResult = false;
            }
          
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Trace.WriteLine("(Window closed) retryLogin: " + this.mustExit );
            if (this.mustExit) { 
                Environment.Exit(0);
            }
        }
    }
}
