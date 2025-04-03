using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using WPF_Experimentation.EF;

namespace WPF_Experimentation
{
    /// <summary>
    /// Auteur :      Hugo St-Louis
    /// Description : Expérimentation avec Entity Framework Core et WPF
    /// Date :        2023-02-20
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationDbContext? _context = null;
        private CollectionViewSource? _contactViewSource;
        private ObservableCollection<Contact> _contacts;


        public MainWindow()
        {
            InitializeComponent();

        }


        /// <summary>
        /// Lors de la fermeture de la fenêtre, ferme la connexion vers la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            // Terminer la connexion vers la base de données
            if (_context != null)
                _context.Dispose();

        }

        /// <summary>
        /// Chargement de la fenêtre : Charge les CollectionViewSource avec les enregistrements appropriés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _context = new ApplicationDbContext();

            _contactViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contactViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            _contacts = new ObservableCollection<Contact>(_context.Contacts.Include("Addresses").Take(10).ToList());
            _contactViewSource.Source = _contacts;
            _contactViewSource.View.MoveCurrentToFirst();
            UpdateView();
            cboTitre.ItemsSource = _context.Contacts.Select(c => c.Title).Distinct().ToList();
        }


        /// <summary>
        /// Événement du clic sur le bouton sauvegarder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSauvegarder_Click(object sender, RoutedEventArgs e)
        {
            Contact c = (Contact)_contactViewSource.View.CurrentItem;
            ImageSource img = img1.Source;
            BitmapSource bmp = (BitmapSource)img;

            BitmapImage b1 = ToBitmapImage(bmp);
            c.Photo = Utils.ConvertBitmapSourceToByteArray(img1.Source);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            _contactViewSource.View.Refresh();
            UpdateView();

        }

        /// <summary>
        /// Mise à jour de l'image par rapport à l'item en cours.
        /// </summary>
        private void UpdateView()
        {
            Contact? currentContact = _contactViewSource.View.CurrentItem as Contact;
            if (currentContact != null)
                img1.Source = currentContact?.Photo != null ? Utils.ConvertByteArrayToBitmapImage(currentContact.Photo) : null;
        }

        /// <summary>
        /// Convertit un BitmapSource en BitmapImage
        /// </summary>
        /// <param name="bitmapSource"></param>
        /// <returns></returns>
        private BitmapImage ToBitmapImage(BitmapSource bitmapSource)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            MemoryStream memorystream = new MemoryStream();
            BitmapImage tmpImage = new BitmapImage();
            if (bitmapSource != null)
            {
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                encoder.Save(memorystream);

                tmpImage.BeginInit();
                tmpImage.StreamSource = new MemoryStream(memorystream.ToArray());
                tmpImage.EndInit();

                memorystream.Close();
            }
            return tmpImage;
        }

        /// <summary>
        /// Sélectionne une photo dans l'ordinateur de type bitmap et l'affiche dans l'image de la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouterPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;";
            if (op.ShowDialog() == true)
            {
                img1.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            _contactViewSource.View.MoveCurrentToFirst();
            UpdateView();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            _contactViewSource.View.MoveCurrentToPrevious();
            UpdateView();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            _contactViewSource.View.MoveCurrentToNext();
            UpdateView();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            _contactViewSource.View.MoveCurrentToLast();
            UpdateView();
        }

        /// <summary>
        /// Crée une nouvel enregistrement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNouvelEnregistrement_Click(object sender, RoutedEventArgs e)
        {
            Contact c = new Contact();
            c.AddDate = DateTime.Now;
            c.ModifiedDate = DateTime.Now;
            _context.Contacts.Add(c);
            _contacts.Add(c);
            _contactViewSource.View.MoveCurrentTo(c);
            _contactViewSource.View.Refresh();
        }

        /// <summary>
        /// Supprimer un enregistrement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Contact c = (Contact)_contactViewSource.View.CurrentItem;
            _context.Contacts.Remove(c);
            _contacts.Remove(c);

        }
    }
}
