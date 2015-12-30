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

namespace HTPC_Project
{
    /// <summary>
    /// Interaction logic for PictureWindow.xaml
    /// </summary>
    public partial class PictureWindow : UserControl
    {
        public string[] pictures;

        private int i = 0;
        private int result;



        // topBar topbar = new topBar();
        public PictureWindow()
        {
            InitializeComponent();
       //     grid.Children.Add(topbar);

        }

        private void button4_Copy1_Click(object sender, RoutedEventArgs e)
        {
            i++;
            result = i % pictures.Length;

            Uri uri = new Uri(pictures [result], UriKind.RelativeOrAbsolute);
            BitmapImage img = new BitmapImage(uri);

            Photo.Source = img;
        }

        private void button4_Copy_Click(object sender, RoutedEventArgs e)
        {
            i--;
            if (i < 0) { i = pictures.Length; }

            result = i % pictures.Length;

            Uri uri = new Uri(pictures[result], UriKind.RelativeOrAbsolute);
            BitmapImage img = new BitmapImage(uri);
            Photo.Source = img;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateTo(new MainWindowContoller());
        }

        private void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            i--;
            if (i < 0) { i = pictures.Length; }

            result = i % pictures.Length;

            Uri uri = new Uri(pictures[result], UriKind.RelativeOrAbsolute);
            BitmapImage img = new BitmapImage(uri);
            Photo.Source = img;
        }

        private void elipse2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            i++;
            result = i % pictures.Length;

            Uri uri = new Uri(pictures[result], UriKind.RelativeOrAbsolute);
            BitmapImage img = new BitmapImage(uri);

            Photo.Source = img;

        }
    }
}
