using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_Experimentation
{
    /// <summary>
    /// Auteur :      Hugo St-Louis
    /// Description : Classe utilitaire qui permet de manipuler une image.
    /// Date :        2023-02-20
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Convertit un BitmapSource en un tableau de byte(image binaire)
        /// </summary>
        /// <param name="encoder"></param>
        /// <param name="imageSource"></param>
        /// <returns>Une image binaire</returns>
        public static byte[] ConvertBitmapSourceToByteArray(BitmapEncoder encoder, ImageSource imageSource)
        {
            byte[] bytes = null;
            var bitmapSource = imageSource as BitmapSource;

            if (bitmapSource != null)
            {
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

                using (var stream = new MemoryStream())
                {
                    encoder.Save(stream);
                    bytes = stream.ToArray();
                }
            }

            return bytes;
        }

        /// <summary>
        /// Convertit un BitmapSource en un tableau de byte(image binaire)
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Une image binaire</returns>
        public static byte[] ConvertBitmapSourceToByteArray(BitmapSource image)
        {
            byte[] data;
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
        /// <summary>
        /// Convertit un BitmapSource en un tableau de byte(image binaire)
        /// </summary>
        /// <param name="imageSource"></param>
        /// <returns>Une image binaire</returns>
        public static byte[] ConvertBitmapSourceToByteArray(ImageSource imageSource)
        {
            var image = imageSource as BitmapSource;
            byte[]? data = null;
            if (imageSource != null)
            {
                BitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                }
            }
            return data;
        }

        /// <summary>
        /// Convertit un BitmapSource en un tableau de byte(image binaire)
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>Une image binaire</returns>
        public static byte[] ConvertBitmapSourceToByteArray(Uri uri)
        {
            var image = new BitmapImage(uri);
            byte[] data;
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        /// <summary>
        /// Convertit un BitmapSource en un tableau de byte(image binaire)
        /// </summary>
        /// <param name="filepath"></param>       
        /// <returns>Une image binaire</returns>
        public static byte[] ConvertBitmapSourceToByteArray(string filepath)
        {
            var image = new BitmapImage(new Uri(filepath));
            byte[] data;
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        /// <summary>
        /// Convertit en un tableau de byte(image binaire) en BitmapImage
        /// </summary>
        /// <param name="encoder"></param>
        /// <param name="imageSource"></param>
        /// <returns>Une image binaire</returns>
        public static BitmapImage ConvertByteArrayToBitmapImage(Byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            stream.Seek(0, SeekOrigin.Begin);
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }
    }
}
