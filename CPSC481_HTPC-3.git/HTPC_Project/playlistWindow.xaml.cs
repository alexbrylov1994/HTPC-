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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class playlistWindow : UserControl
    {

        private string songName, songArtist, songAlbum, songDuration;

        public playlistWindow()
        {
            InitializeComponent();

            String path = "..\\..\\Graphics\\";

            this.remove.text.Text = "Remove";
            this.remove.image.Source = new BitmapImage(new Uri(path + "deleteIcon.png", UriKind.RelativeOrAbsolute));

            this.addSong.text.Text = "Add Song";
            this.addSong.image.Source = new BitmapImage(new Uri(path + "add.png", UriKind.RelativeOrAbsolute));

            this.play.text.Text = "Play All";
            this.play.image.Source = new BitmapImage(new Uri(path + "play.png", UriKind.RelativeOrAbsolute));

        }

        public void setName(string name)
        {
            this.playlistTitle.Content = name;
        }

        private void songClicked(object sender, MouseButtonEventArgs e)
        {
            try
            {
                foreach (SongItem item in songs.Children)
                {
                    if (item.IsMouseOver)
                    {
                        if (item.Check.IsChecked == true)
                        {
                            item.Check.IsChecked = false;
                        }
                        else
                        {
                            item.Check.IsChecked = true;
                        }
                    }
                }
            }
            catch
            {

            }
        }




        private void addSongs(object sender, MouseButtonEventArgs e)
        {
            AddSongs.Visibility = Visibility.Visible;
        }

        private void playMusic(object sender, MouseButtonEventArgs e)
        {
            Navigation.NavigateTo(new MusicPlayBack());
        }

        private void removeSongs(object sender, MouseButtonEventArgs e)
        {
            bool nothingchecked = true;
            foreach (SongItem item in songs.Children)
            {
                if (item.Check.IsChecked == true)
                {
                    nothingchecked = false;
                }
            }
            if (!nothingchecked)
            {
                msg.Visibility = Visibility.Visible;
            }
        }

        private void removeItems()
        {
            try
            {
                foreach (SongItem child in songs.Children)
                {
                    if (child.Check.IsChecked == true)
                    {
                        songs.Children.Remove(child);
                    }
                }
            }
            catch
            {
                removeItems();
            }
        }

        private void AddOk(object sender, RoutedEventArgs e)
        {
            SongItem temp = new SongItem();
            temp.name.Content = songName;
            temp.artist.Content = songArtist;
            temp.album.Content = songAlbum;
            temp.duration.Content = songDuration;

            temp.MouseDown += songClicked;
            temp.MouseDoubleClick += playMusic;

            songs.Children.Add(temp);
            this.names.Clear();
            this.artists.Clear();
            this.albums.Clear();
            this.durations.Clear();
            AddSongs.Visibility = Visibility.Collapsed;
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

        private void albumChanged(object sender, TextChangedEventArgs e)
        {
            songAlbum = this.albums.Text;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.names.Clear();
            this.artists.Clear();
            this.albums.Clear();
            this.durations.Clear();
            AddSongs.Visibility = Visibility.Collapsed;
        }

        private void yes(object sender, RoutedEventArgs e)
        {
            removeItems();
            msg.Visibility = Visibility.Collapsed;
        }

        private void no(object sender, RoutedEventArgs e)
        {
            msg.Visibility = Visibility.Collapsed;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateTo(new MainWindowContoller());
        }

    }
}
