using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Linq;

namespace HTPC_Project
{
    /// <summary>
    /// Interaction logic for MusicWindow.xaml
    /// </summary>
    public partial class MusicWindow : UserControl
    {

        private bool songinc = true, artistinc = true, albuminc = true, durationinc = true;
        private string songName, songArtist, songAlbum, songDuration,playlistName;
        List<SongItem> AllSongs;

        public MusicWindow()
        {
            this.InitializeComponent();
            String path = "..\\..\\Graphics\\";

            AllSongs = new List<SongItem>();

            //add all items in songs to this list
            foreach (SongItem child in songs.Children)
            {
                AllSongs.Add(child);
            }

            sort(AllSongs, true, "name");

            removeAll(this.songs);
            addAll(this.songs, AllSongs);
            this.Song1.name.Content = "a";

            this.Shuffle.text.Text = "Shuffle All";
            this.Shuffle.image.Source = new BitmapImage(new Uri(path + "shuffle.png", UriKind.RelativeOrAbsolute));

            this.play.text.Text = "Play All";
            this.play.image.Source = new BitmapImage(new Uri(path + "play.png", UriKind.RelativeOrAbsolute));

            this.delete.text.Text = "Delete Items";
            this.delete.text.FontSize = 16;
            this.delete.image.Source = new BitmapImage(new Uri(path + "deleteIcon.png", UriKind.RelativeOrAbsolute));

            this.firstPlaylist.playlistTitle.Content = "My First Playlist";
            this.secondPlaylist.playlistTitle.Content = "My Second Playlist";

            this.remove.text.Text = "Remove";
            this.remove.image.Source = new BitmapImage(new Uri(path + "deleteIcon.png", UriKind.RelativeOrAbsolute));

            this.addPlaylist.text.Text = "New Playlist";
            this.addPlaylist.text.FontSize = 16;
            this.addPlaylist.image.Source = new BitmapImage(new Uri(path + "add.png", UriKind.RelativeOrAbsolute));

            this.add.text.Text = "Add Song";
            this.add.image.Source = new BitmapImage(new Uri(path + "add.png", UriKind.RelativeOrAbsolute));

            this.addToPlaylist.text.Text = "Add to Playlist";
            this.addToPlaylist.text.FontSize = 12;
            this.addToPlaylist.image.Source = new BitmapImage(new Uri(path + "add.png", UriKind.RelativeOrAbsolute));

        }

        public List<SongItem> sort(List<SongItem> list, bool asc, string type)
        {
            if (asc)
            {
                switch (type)
                {
                    case "name":
                        list = list.OrderBy(x => x.name.Content).ToList();
                        break;

                    case "artist":
                        list = list.OrderBy(x => x.artist.Content).ToList();
                        break;

                    case "album":
                        list = list.OrderBy(x => x.album.Content).ToList();
                        break;

                    case "duration":
                        list = list.OrderBy(x => x.duration.Content).ToList();
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case "name":
                        list = list.OrderByDescending(x => x.name.Content).ToList();
                        break;

                    case "artist":
                        list = list.OrderByDescending(x => x.artist.Content).ToList();
                        break;

                    case "album":
                        list = list.OrderByDescending(x => x.album.Content).ToList();
                        break;

                    case "duration":
                        list = list.OrderByDescending(x => x.duration.Content).ToList();
                        break;
                }
            }

            return list;
        }

        private void removeAll(StackPanel stackpanel)
        {
            while (stackpanel.Children.Count > 0)
            {
                stackpanel.Children.RemoveAt(stackpanel.Children.Count - 1);
            }
        }

        private void addAll(StackPanel stackpanel, List<SongItem> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                stackpanel.Children.Add(list[i]);
            }
        }

        private void playSongClicked(object sender, MouseButtonEventArgs e)
        {
            Navigation.NavigateTo(new MusicPlayBack());
        }

        private void playSongClickedOnce(object sender, MouseButtonEventArgs e)
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

        private void album_clicked(object sender, MouseButtonEventArgs e)
        {
            Navigation.NavigateTo(new AlbumWindow());
        }

        private void playlist_clicked(object sender, MouseButtonEventArgs e)
        {

            try
            {
                foreach (playlistItem item in playlists.Children)
                {
                    if (item.IsMouseOver == true)
                    {
                        if (item.check.IsChecked == true)
                        {
                            item.check.IsChecked = false;
                        }
                        else
                        {
                            item.check.IsChecked = true;
                        }

                    }
                }
            }
            catch
            {

            }
        }



        private void playlist1_doubleclicked(object sender, MouseButtonEventArgs e)
        {
            playlistWindow playlist = new playlistWindow();
            Navigation.NavigateTo(playlist);
            playlist.setName("My First Playlist");
        }

        private void playlist2_doubleclicked(object sender, MouseButtonEventArgs e)
        {
            playlistWindow playlist = new playlistWindow();
            Navigation.NavigateTo(playlist);
            playlist.setName("My second Playlist");
        }




        private void SongSort(object sender, MouseButtonEventArgs e)
        {
            if (songArrowDown.Opacity == 1 || songArrowUp.Opacity == 1)
            {
                if (!songinc)
                {
                    songinc = true;
                    updateArrows(); //make all arrows invisible
                    this.songArrowDown.Opacity = 1; //makes up arrow visible
                }
                else
                {
                    songinc = false;
                    updateArrows(); //make all arrows invisible
                    this.songArrowUp.Opacity = 1; //make down arrow visible
                }
            }
            else
            {
                if (songinc)
                {
                    updateArrows(); //make all arrows invisible
                    this.songArrowDown.Opacity = 1;
                }
                else
                {
                    updateArrows(); //make all arrows invisible
                    this.songArrowUp.Opacity = 1;

                }
            }

            AllSongs = sort(AllSongs, songinc, "name");

            //update songs panel
            removeAll(songs);
            addAll(songs, AllSongs);
        }

        /// <summary>
        /// makes all arrows invisible so that changes can be made
        /// </summary>
        private void updateArrows()
        {
            this.songArrowUp.Opacity = 0;
            this.songArrowDown.Opacity = 0;
            this.artistArrowUp.Opacity = 0;
            this.artistArrowDown.Opacity = 0;
            this.albumArrowUp.Opacity = 0;
            this.albumArrowDown.Opacity = 0;
            this.durationArrowUp.Opacity = 0;
            this.durationArrowDown.Opacity = 0;
        }

        private void ArtistSort(object sender, MouseButtonEventArgs e)
        {
            if (artistArrowDown.Opacity == 1 || artistArrowUp.Opacity == 1)
            {
                if (!artistinc)
                {
                    artistinc = true;
                    updateArrows(); //make all arrows invisible
                    this.artistArrowDown.Opacity = 1; //makes up arrow visible
                }
                else
                {
                    artistinc = false;
                    updateArrows(); //make all arrows invisible
                    this.artistArrowUp.Opacity = 1; //make down arrow visible
                }
            }
            else
            {
                if (artistinc)
                {
                    updateArrows(); //make all arrows invisible
                    this.artistArrowDown.Opacity = 1;
                }
                else
                {
                    updateArrows(); //make all arrows invisible
                    this.artistArrowUp.Opacity = 1;

                }
            }

            AllSongs = sort(AllSongs, artistinc, "artist");

            //update songs panel
            removeAll(songs);
            addAll(songs, AllSongs);
        }

        private void AlbumSort(object sender, MouseButtonEventArgs e)
        {
            if (albumArrowDown.Opacity == 1 || albumArrowUp.Opacity == 1)
            {
                if (!albuminc)
                {
                    albuminc = true;
                    updateArrows(); //make all arrows invisible
                    this.albumArrowDown.Opacity = 1; //makes up arrow visible
                }
                else
                {
                    albuminc = false;
                    updateArrows(); //make all arrows invisible
                    this.albumArrowUp.Opacity = 1; //make down arrow visible
                }
            }
            else
            {
                if (albuminc)
                {
                    updateArrows(); //make all arrows invisible
                    this.albumArrowDown.Opacity = 1;
                }
                else
                {
                    updateArrows(); //make all arrows invisible
                    this.albumArrowUp.Opacity = 1;

                }
            }

            AllSongs = sort(AllSongs, albuminc, "album");

            //update songs panel
            removeAll(songs);
            addAll(songs, AllSongs);
        }

        private void DurationSort(object sender, MouseButtonEventArgs e)
        {
            if (durationArrowDown.Opacity == 1 || durationArrowUp.Opacity == 1)
            {
                if (!durationinc)
                {
                    durationinc = true;
                    updateArrows(); //make all arrows invisible
                    this.durationArrowDown.Opacity = 1; //makes up arrow visible
                }
                else
                {
                    durationinc = false;
                    updateArrows(); //make all arrows invisible
                    this.durationArrowUp.Opacity = 1; //make down arrow visible
                }
            }
            else
            {
                if (durationinc)
                {
                    updateArrows(); //make all arrows invisible
                    this.durationArrowDown.Opacity = 1;
                }
                else
                {
                    updateArrows(); //make all arrows invisible
                    this.durationArrowUp.Opacity = 1;

                }
            }

            AllSongs = sort(AllSongs, durationinc, "duration");

            //update songs panel
            removeAll(songs);
            addAll(songs, AllSongs);
        }

        private void updateSonglist(StackPanel panel, List<SongItem> list)
        {
            list.Clear();
            foreach (SongItem item in panel.Children)
            {
                list.Add(item);
            }
        }


        private void removeSongs()
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
                removeSongs();
            }
        }

        private void RemoveClick(object sender, MouseButtonEventArgs e)
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
                this.msg.Visibility = Visibility.Visible;
            }

        }

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                foreach (SongItem item in songs.Children)
                {
                    string temp = item.name.Content.ToString();
                    if (item.name.Content.ToString().ToLower().Contains(this.search.Text.ToString().ToLower()) || (item.artist.Content.ToString().ToLower().Contains(this.search.Text.ToString().ToLower())) || item.album.Content.ToString().ToLower().Contains(this.search.Text.ToString().ToLower()))
                    {
                        item.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        item.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch
            {

            }
        }

        private void addClick(object sender, MouseButtonEventArgs e)
        {
            AddSong.Visibility = Visibility.Visible;
        }

        private void RemovePlaylist(object sender, MouseButtonEventArgs e)
        {
            bool nothingchecked = true;
            foreach (playlistItem item in playlists.Children)
            {
                if (item.check.IsChecked == true)
                {
                    nothingchecked = false;
                }
            }
            if (!nothingchecked)
            {
                playlistmsg.Visibility = Visibility.Visible;
            }
        }

        private void removePlaylists()
        {
            try
            {
                foreach (playlistItem child in playlists.Children)
                {
                    if (child.check.IsChecked == true)
                    {
                        playlists.Children.Remove(child);
                    }
                }
            }
            catch
            {
                removePlaylists();
            }
        }

        private void playlistAdd(object sender, MouseButtonEventArgs e)
        {
            playlistMake.Visibility = Visibility.Visible;
        }

        private void no(object sender, RoutedEventArgs e)
        {
            msg.Visibility = Visibility.Collapsed;
        }

        private void Yes(object sender, RoutedEventArgs e)
        {
             removeSongs();
             msg.Visibility = Visibility.Collapsed;
            
        }

        private void pyes(object sender, RoutedEventArgs e)
        {
            playlistmsg.Visibility = Visibility.Collapsed;
            removePlaylists();
        }

        private void addOK(object sender, RoutedEventArgs e)
        {
            SongItem temp = new SongItem();
            temp.name.Content = songName;
            temp.artist.Content = songArtist;
            temp.album.Content = songAlbum;
            temp.duration.Content = songDuration;

            temp.MouseDown += playSongClickedOnce;
            temp.MouseDoubleClick += playSongClicked;


            songs.Children.Add(temp);

            updateSonglist(songs, AllSongs);
            this.names.Clear();
            this.artists.Clear();
            this.albums.Clear();
            this.durations.Clear();
            AddSong.Visibility = Visibility.Collapsed;

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

        private void addSongClose(object sender, RoutedEventArgs e)
        {
            this.AddSong.Visibility = Visibility.Collapsed;
            this.names.Clear();
            this.artists.Clear();
            this.albums.Clear();
            this.durations.Clear();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateTo(new MainWindowContoller());
        }

        private void playlistOK(object sender, RoutedEventArgs e)
        {
            playlistItem temp = new playlistItem();
            temp.playlistTitle.Content = playlistName;
            temp.MouseDown += playlist_clicked;
            temp.MouseDoubleClick += playlist1_doubleclicked;
            playlists.Children.Add(temp);
            playlistMake.Visibility = Visibility.Collapsed;
        }

        private void playlistText(object sender, TextChangedEventArgs e)
        {
            playlistName = this.text.Text;
        }

        private void playlistCancel(object sender, RoutedEventArgs e)
        {
            playlistMake.Visibility = Visibility.Collapsed;
        }

        private void pno(object sender, RoutedEventArgs e)
        {
            playlistmsg.Visibility = Visibility.Collapsed;
        }


    }
}