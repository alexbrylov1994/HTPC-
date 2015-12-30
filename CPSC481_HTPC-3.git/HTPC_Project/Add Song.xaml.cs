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

namespace HTPC_Project
{
    /// <summary>
    /// Interaction logic for Add_Song.xaml
    /// </summary>
    public partial class Add_Song : Window
    {
        private string songName, songArtist, songAlbum, songDuration, songStatus;
        public Add_Song()
        {
            InitializeComponent();
        }

        public string name
        {
            get { return songName; }
        }

        public string artist
        {
            get { return songArtist; }
        }

        public string album
        {
            get { return songAlbum; }
        }

        public string duration
        {
            get { return songDuration; }
        }

        public string status
        {
            get { return songStatus; }
        }

        private void nameChanged(object sender, TextChangedEventArgs e)
        {
            songName = this.names.Text;
        }

        private void artistChanged(object sender, TextChangedEventArgs e)
        {
            songArtist = this.artists.Text;
        }

        private void durationChanged(object sender, TextChangedEventArgs e)
        {
            songDuration = this.durations.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            songStatus = "ok";
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void albumChanged(object sender, TextChangedEventArgs e)
        {
            songAlbum = this.albums.Text;
        }



    }
}
