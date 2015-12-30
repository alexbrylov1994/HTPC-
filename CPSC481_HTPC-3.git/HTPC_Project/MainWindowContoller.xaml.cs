using System;
using System.Collections.Generic;
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
using System.Xml;

namespace HTPC_Project
{
    /// <summary>
    /// Interaction logic for MainWindowContoller.xaml
    /// </summary>
    /// 

    public partial class MainWindowContoller : UserControl
    {
        //topBarMain topbar = new topBarMain();
        AddFromPCController pcCont = new AddFromPCController();
        MoviePlayBack movie = new MoviePlayBack();
        dotsControl menu = new dotsControl();
//        private NetflixMain netflixmain = new NetflixMain();
        InstalServices services = new InstalServices();
        HuluWindow hulu = new HuluWindow();
        PictureWindow picture = new PictureWindow();
        
        SearchControl search = new SearchControl();

        MusicWindow musicwindow = new MusicWindow();
        

        public static string DESCRIPTION = "\\description.txt";
        public static string POSTER = "\\poster.bmp";


/*        public NetflixMain Netflixmain
        {
            get
            {
                return this.netflixmain;
            }
        }*/

        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

        Button button;
        Iconloader directories;

        Iconloader musicdirectory;
        Iconloader photodirectory;


        public MainWindowContoller()
        {
            InitializeComponent();

            dotsControl.main = this;

            InstalServices.main = this;

            MoreInfoIcon.main = this;



            //string filepath = "C:\\Users\\spenc\\Documents\\MovieTypes";
            string filepath = "Movies\\";//"C:\\Users\\spenc\\Documents\\MovieTypes";

            string filepathPhotos = "Pictures\\";
            string filepathMusic = "Music\\";

            XmlNode node;
            // mainGrid.Children.Add(topbar);
            // this.Closed += MainWindow_Closed;

            //Navigation.ContentContainer = mainGrid;

            //   Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //   dlg.ShowDialog();
            this.directories = new Iconloader();
            this.directories.LoadDirectories(filepath);

            this.photodirectory = new Iconloader();
            this.photodirectory.LoadFiles(filepathPhotos);

            this.musicdirectory = new Iconloader();
            this.musicdirectory.LoadFiles(filepathMusic);



            makeDefaultbuttons();
            MakeIcons();

            MakeIconsPictures();
            MakeIconsMusic();
            addFavourites();

        }

        void AddService()
        {
            try
            {
                // Netlif default
                Uri uri = new Uri("pack://application:,,/HTPC_Project;component/Graphics/Hulu-UK-Unblock-and-Watch-Hulu-Plus-outside-USA.jpg", UriKind.RelativeOrAbsolute);
                BitmapImage img = new BitmapImage(uri);
                MoreInfoIcon app = new MoreInfoIcon();
                MoreInfoIcon appsearch = new MoreInfoIcon();

                app.Icon.Source = img;
                appsearch.Icon.Source = app.Icon.Source = img;

                app.ButtonLabel.Content = "Hulu";
                appsearch.ButtonLabel.Content = app.ButtonLabel.Content = "Hulu";

                app.MouseDown += Hulu_MouseDown;
                appsearch.MouseDown += Hulu_MouseDown;
                //MovieElement.UniformGrid.Children.Add(app);
                //MovieElement.UniformGrid.Children.RemoveAt(0);
                MovieElement.UniformGrid.Children.Insert(0, app);
                appsearch.Close.Visibility = Visibility.Collapsed;
                search.grid.Children.Add(appsearch);


            }

            catch (Exception e)
            {

                // Do nothing
            }
        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void button1_Copy11_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Add(pcCont);
            dlg.ShowDialog();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Navigation.NavigateTo(new MusicWindow());
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollviewer = sender as ScrollViewer;
            if (e.Delta > 0)
                scrollviewer.LineLeft();
            else
                scrollviewer.LineRight();
            e.Handled = true;
        }

        private void button_Options(object sender, RoutedEventArgs e)
        {
            Button button = ((Button)sender);

            Thickness margin = button.Margin;
            margin.Top += 0;
            margin.Left -= 190;
            menu.Margin = margin;

            // (button.Parent as Panel).Children.Add(menu);

            if ((button.Parent as Panel).Children.Contains(menu))
            {
                (button.Parent as Panel).Children.Remove(menu);
            }
            else
            {
                (button.Parent as Panel).Children.Add(menu);
            }


        }

        /// <summary>
        /// Taken From PicturO (temporarily anyway)
        /// </summary>
        /// 

        void makeDefaultbuttons()
        {
            try
            {
                // Netlif default
                Uri uri = new Uri("pack://application:,,/HTPC_Project;component/Graphics/netflix-logo.jpg", UriKind.RelativeOrAbsolute);
                BitmapImage img = new BitmapImage(uri);

                MoreInfoIcon netflixApp = new MoreInfoIcon(true);
                MoreInfoIcon searchNetflixApp = new MoreInfoIcon();

                searchNetflixApp.Icon.Source = netflixApp.Icon.Source = img;
                searchNetflixApp.ButtonLabel.Content = netflixApp.ButtonLabel.Content = "Netflix";

                
                netflixApp.MouseDown += Netflix_MouseDown;
                
                searchNetflixApp.MouseDown += Netflix_MouseDown;

                MovieElement.UniformGrid.Children.Add(netflixApp);

                searchNetflixApp.Close.Visibility = Visibility.Collapsed;
                search.grid.Children.Add(searchNetflixApp);       


                // Spoti  default
                Uri uri1 = new Uri("pack://application:,,/HTPC_Project;component/Graphics/spotify-logo.jpg", UriKind.RelativeOrAbsolute);
                BitmapImage img1 = new BitmapImage(uri1);

                MoreInfoIcon spotifyApp = new MoreInfoIcon();
                MoreInfoIcon spotifyserch = new MoreInfoIcon();

                spotifyApp.Icon.Source = img1;
                spotifyserch.Icon.Source = spotifyApp.Icon.Source = img1;

                spotifyApp.ButtonLabel.Content = "Spotify";
                spotifyserch.ButtonLabel.Content = spotifyApp.ButtonLabel.Content = "Spotify";

                spotifyApp.MouseDown += Spotify_MouseDown;
                spotifyserch.MouseDown += Spotify_MouseDown;

                SongsElement.UniformGrid.Children.Add(spotifyApp);

                spotifyserch.Close.Visibility = Visibility.Collapsed;
                search.grid.Children.Add(spotifyserch);


                // Playlist  default
                Uri ur12 = new Uri("pack://application:,,/HTPC_Project;component/Graphics/playlist1.png", UriKind.RelativeOrAbsolute);
                BitmapImage img2 = new BitmapImage(ur12);
                MoreInfoIcon playlist = new MoreInfoIcon();
                MoreInfoIcon playlistsearch = new MoreInfoIcon();

                playlist.Icon.Source = img2;
                playlistsearch.Icon.Source = playlist.Icon.Source = img2;

                playlist.ButtonLabel.Content = "Playlist";
                playlistsearch.ButtonLabel.Content = playlist.ButtonLabel.Content = "Playlist";

                playlist.MouseDown += Playlist_MouseDown;
                playlistsearch.MouseDown += Playlist_MouseDown;

                SongsElement.UniformGrid.Children.Add(playlist);

                playlistsearch.Close.Visibility = Visibility.Collapsed;
                search.grid.Children.Add(playlistsearch);



                // Album  default
                Uri uri3 = new Uri("pack://application:,,/HTPC_Project;component/Graphics/album3.png", UriKind.RelativeOrAbsolute);
                BitmapImage img3 = new BitmapImage(uri3);
                MoreInfoIcon album = new MoreInfoIcon();
                MoreInfoIcon albumsearch = new MoreInfoIcon();

                album.Icon.Source = img3;
                albumsearch.Icon.Source = album.Icon.Source = img3;

                album.ButtonLabel.Content = "Album";
                albumsearch.ButtonLabel.Content = album.ButtonLabel.Content = "Album";

                album.MouseDown += Album_MouseDown;
                albumsearch.MouseDown += Album_MouseDown;

                SongsElement.UniformGrid.Children.Add(album);

                albumsearch.Close.Visibility = Visibility.Collapsed;
                search.grid.Children.Add(albumsearch); 

            }

            catch (Exception e)
            {

                // Do nothing
            }
        }

        private void Playlist_MouseDown(object sender, MouseButtonEventArgs e)
        {
            musicwindow.PlaylistsTab.IsSelected = true;
            Navigation.NavigateTo(musicwindow);
 
        }

        private void Album_MouseDown(object sender, MouseButtonEventArgs e)
        {
            musicwindow.AlbumsTab.IsSelected = true;
            Navigation.NavigateTo(musicwindow);

        }


        /*

            DO NOT ALTER
        */

        private void Netflix_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Navigation.NavigateTo(new WatchPCMovies());
        }

        private void Hulu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HuluWindow hulu1 = new HuluWindow();

            Navigation.NavigateTo(hulu1);
        }
 

        private void Spotify_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MoreInfoIcon thumbnail = (MoreInfoIcon)sender;

            musicwindow.SongsTab.IsSelected = true;
            Navigation.NavigateTo(musicwindow);
        }

        void MakeIcons()
        {
            // Retrieve the paths
            string[] thumbnails = this.directories.Directories;

            // For each path
            // Create a PhotoTile
            // add the image lead to by the path
            // add the title of the image
            // add the PhotoTile to the PhotoViewerGrid
            /*
            DO NOT ALTER


            */


            if (MovieLists.ActionMovieList.Count == 0)
            {
                foreach (string path in thumbnails)
                {
                    string newPath = path + POSTER;

                    try
                    {
                        // grab the image from the path
                        //                    string newPath = path + POSTER;
                        //                    Uri uri = new Uri(newPath);
                        Uri uri = new Uri(newPath, UriKind.RelativeOrAbsolute);
                        BitmapImage img = new BitmapImage(uri);
                        //img.UriSource = new Uri(newPath, UriKind.RelativeOrAbsolute);

                        MoreInfoIcon thumbnail = new MoreInfoIcon();
                        // set the source of the Image control to the image we got from the path
                        thumbnail.Icon.Source = img;
                        thumbnail.Description = directories.LoadDescription(path + DESCRIPTION);
                        thumbnail.ButtonLabel.Content = directories.Title;

                        // thumbnail.ButtonLabel.Content = directories.

                        // find the name of the file from the path
                        //                    photoTile.ImageTitle.Text = path.Split('\\').Last().Split('.').First();
                        // Subscribe to the PhotoTile's MouseDown event
                        //                    photoTile.MouseDown += new MouseButtonEventHandler(photoTile_MouseDown);
                        // Add the PhotoTile to the PhotoViewerGrid

                        thumbnail.MouseDown += Thumbnail_MouseDown;

                        //                    MovieElement.UniformGrid.Children.Add(thumbnail);
                        MovieLists.ActionMovieList.Add(thumbnail);

                        //Create Separate event handlers for every type
                    }
                    catch (Exception e)
                    {

                        // Do nothing
                    }
                }
            }
        }

/*
        DO NOT ALTER

            */

        void addFavourites()
        {
            try
            {
                foreach (MoreInfoIcon favourite in MovieLists.FavouriteMovieList)
                {
                    MoreInfoIcon newThumbnail = new MoreInfoIcon();
                    MoreInfoIcon movies = new MoreInfoIcon();

                    newThumbnail.Icon.Source = favourite.Icon.Source;
                    movies.Icon.Source = newThumbnail.Icon.Source;

                    newThumbnail.ButtonLabel.Content = favourite.ButtonLabel.Content;
                    movies.ButtonLabel.Content = newThumbnail.ButtonLabel.Content;

                    newThumbnail.MouseDown += Thumbnail_MouseDown;
                    movies.MouseDown += Thumbnail_MouseDown;

                    newThumbnail.Description = favourite.Description;
                    movies.Description = newThumbnail.Description;

                    MovieElement.UniformGrid.Children.Add(newThumbnail);
                    search.grid.Children.Add(movies);
                }
            }
            catch (Exception e2)
            {
                //do nothing
            }
        }



        void MakeIconsPictures()
        {
            // Retrieve the paths
            string[] thumbnails = this.photodirectory.Directories;

            picture.pictures = this.photodirectory.Directories;
            // For each path
            // Create a PhotoTile
            // add the image lead to by the path
            // add the title of the image
            // add the PhotoTile to the PhotoViewerGrid
            foreach (string path in thumbnails)
            {
                string newPath = path;

                try
                {
                    // grab the image from the path
                    //                    string newPath = path + POSTER;
                    //                    Uri uri = new Uri(newPath);
                    Uri uri = new Uri(newPath, UriKind.RelativeOrAbsolute);
                    BitmapImage img = new BitmapImage(uri);
                    //img.UriSource = new Uri(newPath, UriKind.RelativeOrAbsolute);

                    MoreInfoIcon thumbnail = new MoreInfoIcon();
                    MoreInfoIcon pics = new MoreInfoIcon();
                    // set the source of the Image control to the image we got from the path
                    thumbnail.Icon.Source = img;
                    pics.Icon.Source = thumbnail.Icon.Source = img;

                    thumbnail.ButtonLabel.Content = "Picture";
                    pics.ButtonLabel.Content = thumbnail.ButtonLabel.Content = "Picture";

                    // find the name of the file from the path
                    //                    photoTile.ImageTitle.Text = path.Split('\\').Last().Split('.').First();
                    // Subscribe to the PhotoTile's MouseDown event
                    //                    photoTile.MouseDown += new MouseButtonEventHandler(photoTile_MouseDown);
                    // Add the PhotoTile to the PhotoViewerGrid

                    thumbnail.MouseDown += Pictures_MouseDown;

                   // picture.Photo.Source = thumbnail.Icon.Source; 

                    pics.MouseDown += Pictures_MouseDown;

                    PictuesElement.UniformGrid.Children.Add(thumbnail);
                    pics.Close.Visibility = Visibility.Collapsed;
                    search.grid.Children.Add(pics);
                    //Create Separate event handlers for every type
                }
                catch (Exception e)
                {

                    // Do nothing
                }
            }
        }

        private void Pictures_MouseDown(object sender, MouseButtonEventArgs e)
        {
           MoreInfoIcon thumbnail = (MoreInfoIcon)sender;

           picture.Photo.Source = thumbnail.Icon.Source;  


           Navigation.NavigateTo(picture);
        }

        void MakeIconsMusic()
        {
            // Retrieve the paths
            string[] thumbnails = this.musicdirectory.Directories;

            // For each path
            // Create a PhotoTile
            // add the image lead to by the path
            // add the title of the image
            // add the PhotoTile to the PhotoViewerGrid
            foreach (string path in thumbnails)
            {
                string newPath = path;

                try
                {
                    // grab the image from the path
                    //                    string newPath = path + POSTER;
                    //                    Uri uri = new Uri(newPath);
                    Uri uri = new Uri(newPath, UriKind.RelativeOrAbsolute);
                    BitmapImage img = new BitmapImage(uri);
                    //img.UriSource = new Uri(newPath, UriKind.RelativeOrAbsolute);

                    MoreInfoIcon thumbnail = new MoreInfoIcon();
                    MoreInfoIcon songs = new MoreInfoIcon();
                    // set the source of the Image control to the image we got from the path
                    thumbnail.Icon.Source = img;
                    songs.Icon.Source = thumbnail.Icon.Source = img;

                    thumbnail.ButtonLabel.Content = "Song";
                    songs.ButtonLabel.Content = thumbnail.ButtonLabel.Content = "Song";

                    // find the name of the file from the path
                    //                    photoTile.ImageTitle.Text = path.Split('\\').Last().Split('.').First();
                    // Subscribe to the PhotoTile's MouseDown event
                    //                    photoTile.MouseDown += new MouseButtonEventHandler(photoTile_MouseDown);
                    // Add the PhotoTile to the PhotoViewerGrid

                    thumbnail.MouseDown += Music_MouseDown;
                    songs.MouseDown += Music_MouseDown;

                    SongsElement.UniformGrid.Children.Add(thumbnail);
                    songs.Close.Visibility = Visibility.Collapsed;
                    search.grid.Children.Add(songs);
                    //Create Separate event handlers for every type
                }
                catch (Exception e)
                {

                    // Do nothing
                }
            }
        }

        private void Music_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MusicPlayBack music = new MusicPlayBack();
            MoreInfoIcon thumbnail = (MoreInfoIcon)sender;
            music.SongLabel.Source = thumbnail.Icon.Source;




            Navigation.NavigateTo(music);
        }

        public void fromPC(object sender, RoutedEventArgs e)
        {
           // Button button = ((Button)sender);
           mainGrid.Children.Remove(menu);
            mainGrid.Children.Add(pcCont);
            //Button button = ((Button)sender);


        }

        public void addService(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Add(services);
            mainGrid.Children.Remove(menu);
        }

/*
        DO NOT ALTER


            */
            

        private void Thumbnail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NetflixMain netflixMain = new NetflixMain();
            MoviePlayBack playback = new MoviePlayBack();
            MoreInfoIcon thumbnail = (MoreInfoIcon)sender;

            netflixMain.MoviePoster.Source = thumbnail.Icon.Source;
            netflixMain.MovieDescription.Text = thumbnail.Description;
            netflixMain.Title = thumbnail.ButtonLabel.Content.ToString();
            netflixMain.MoreLike.Text = "More Like: " + thumbnail.ButtonLabel.Content.ToString();
            netflixMain.favouriteButtonCheck();

            playback.Movieplay.Source = thumbnail.Icon.Source;


            //netflixMain.Title = (sender as MoreInfoIcon).Title;
            //netflixMain.image.Source = (sender as MoreInfoIcon).Image.Source;

            Navigation.NavigateTo(netflixMain);
        }

        private void button1_Copy26_Click(object sender, RoutedEventArgs e)
        {
            button = ((Button)sender);

            Thickness margin = button.Margin;
            margin.Top -= 26;
            margin.Left += 50;
            menu.Margin = margin;

            if (mainGrid.Children.Contains(menu))
            {
                (button.Parent as Panel).Children.Remove(menu);
            }
            else
            {
                (button.Parent as Panel).Children.Add(menu);
            }
        }
        /*
        private void button1_Copy3_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateTo(new NetflixMain());
        }

        private void button1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateTo(new PictureWindow());
        }

        private void button1_Copy7_MouseEnter(object sender, MouseEventArgs e)
        {
            Navigation.NavigateTo(new NetflixMain());
        }

        private void button1_Copy6_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateTo(new Window4());
        }

        private void button1_Copy7_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateTo(new NetflixMain());
        }

        private void button1_Copy2_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateTo(new WatchPCMovies());
        } */

        private void shit_Click(object sender, RoutedEventArgs e)
        {
            AddService();
        }

        public void addService_Click(object sender, RoutedEventArgs e)
        {
            AddService();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Add(services);
        }

        private void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (mainGrid.Children.Contains(search))
            {
                mainGrid.Children.Remove(search);
            }
            else
            {
                mainGrid.Children.Add(search);
            }


        }
    }
}