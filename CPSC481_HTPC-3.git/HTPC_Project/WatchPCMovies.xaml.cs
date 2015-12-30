
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

namespace HTPC_Project
{
    /// <summary>
    /// Interaction logic for WatchPCMovies.xaml
    /// </summary>
    public partial class WatchPCMovies : UserControl
    {
        // topBar topbar = new topBar();

        Iconloader directories;
        private static string POSTER = "poster.bmp";
        private static string DESCRIPTION = "description.txt";
        MovieContainerControl[] Genre;
        private bool onSearch = false;

        public WatchPCMovies()
        {
            InitializeComponent();
            StreamReader reader;
            string title;
            string relativePath = "..\\..\\Genres\\Genres.txt";
            string fullPath = System.IO.Path.GetFullPath(relativePath);
            this.UpArrow.DirectionalArrow.Orientation = Microsoft.Expression.Media.ArrowOrientation.Up;
            this.UpArrow.Visibility = Visibility.Hidden;
            int index = 0;
            Genre = new MovieContainerControl[9];

            try
            {
                reader = new StreamReader(fullPath);
                while (!reader.EndOfStream)
                {
                    title = reader.ReadLine();
                    Genre[index] = new MovieContainerControl(title);
                    //                    MovieContainerControl Genre = new MovieContainerControl(title);n
                    this.RectangleGrid.Children.Add(Genre[index]);



                }
            }
            catch (Exception e) { }
            this.SearchGrid.Visibility = Visibility.Collapsed;

            try
            {
                foreach (MoreInfoIcon icon in MovieLists.ActionMovieList)
                {
                    SearchNetflixMovies searchElement = new SearchNetflixMovies();
                    searchElement.poster.Source = icon.Icon.Source;
                    searchElement.title.Text = icon.ButtonLabel.Content.ToString();
                    searchElement.description.Text = icon.Description;
                    searchElement.NewIcon = icon;
                    searchElement.checkFavourites();
                    this.ListofMovies.Children.Add(searchElement);


                }
            }
            catch (Exception e)
            {
                //do nothing
            }
            //     WatchPCMovies_Grids.Children.Add(topbar);
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
            foreach (string path in thumbnails)
            {
                try
                {
                    // grab the image from the path
                    string newPath = path + POSTER;
                    Uri uri = new Uri(newPath);
                    BitmapImage img = new BitmapImage(uri);

                    MoreInfoIcon thumbnail = new MoreInfoIcon();
                    // set the source of the Image control to the image we got from the path
                    thumbnail.Icon.Source = img;
                    thumbnail.Description = directories.LoadDescription(path + DESCRIPTION);
                    thumbnail.ButtonLabel.Content = directories;
                    thumbnail.MouseDown += Thumbnail_MouseDown;

                    // find the name of the file from the path
                    //                    photoTile.ImageTitle.Text = path.Split('\\').Last().Split('.').First();
                    // Subscribe to the PhotoTile's MouseDown event
                    //                    photoTile.MouseDown += new MouseButtonEventHandler(photoTile_MouseDown);
                    // Add the PhotoTile to the PhotoViewerGrid


                    //MovieElement.UniformGrid.Children.Add(thumbnail);
                    //Create Separate event handlers for every type
                }
                catch (Exception e)
                {
                    // Do nothing
                }
            }
        }

        private void Thumbnail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Navigation.NavigateTo(new NetflixMain());
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Scroller_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollviewer = sender as ScrollViewer;
            if (e.Delta > 0)
                scrollviewer.LineUp();
            else
                scrollviewer.LineDown();
            e.Handled = true;
        }

        private void DownArrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            for (int index = 0; index < 30; index++)
                Scroller.LineDown();

            if (Scroller.ViewportHeight - Scroller.VerticalOffset < 30)
            {
                DownArrow.Visibility = Visibility.Hidden;
            }

            UpArrow.Visibility = Visibility.Visible;
        }

        private void UpArrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double n = Scroller.VerticalOffset;

            for (int index = 0; index < 30; index++)
                Scroller.LineUp();

            if (Scroller.VerticalOffset < 500)
            {
                UpArrow.Visibility = Visibility.Hidden;
            }


            DownArrow.Visibility = Visibility.Visible;
        }

        private void searchBox_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!onSearch)
            {
                SearchGrid.Visibility = Visibility.Visible;
                GenreGrid.Visibility = Visibility.Collapsed;
                onSearch = true;
            }
            searchMovies();
        }

        private void searchMovies()
        {
            try
            {
                //Thanks to Brennen for the code
                foreach (SearchNetflixMovies movie in ListofMovies.Children)
                {
                    if (movie.title.Text.ToString().ToLower().Contains(searchBox.Text.ToString().ToLower()))
                    {
                        movie.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        movie.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch (Exception e)
            {
                //do nothing
            }
            if (searchBox.Text.ToString().ToLower() == "")
            {
                SearchGrid.Visibility = Visibility.Collapsed;
                GenreGrid.Visibility = Visibility.Visible;
                onSearch = false;
            }
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowContoller controller = new MainWindowContoller();
            Navigation.NavigateTo(controller);
        }


    }
}

