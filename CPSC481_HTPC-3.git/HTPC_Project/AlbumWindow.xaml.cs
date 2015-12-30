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
    /// Interaction logic for AlbumWindow.xaml
    /// </summary>
    public partial class AlbumWindow : UserControl
    {
        public AlbumWindow()
        {
            InitializeComponent();

            String path = "..\\..\\Graphics\\";

            this.play.text.Text = "Play All";
            this.play.image.Source = new BitmapImage(new Uri(path + "play.png", UriKind.RelativeOrAbsolute));

            this.Shuffle.text.Text = "Shuffle All";
            this.Shuffle.image.Source = new BitmapImage(new Uri(path + "shuffle.png", UriKind.RelativeOrAbsolute));

            this.albumsong.Number.Text = "1.";
            this.albumsong2.Number.Text = "2.";

        }

        private void albumClicked(object sender, MouseButtonEventArgs e)
        {
            Navigation.NavigateTo(new MusicPlayBack());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateTo(new MainWindowContoller());
        }
    }
}
