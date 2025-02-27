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

        }

        /// <summary>
        /// Chargement de la fenêtre : Charge les CollectionViewSource avec les enregistrements appropriés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

 

     
    }
}
