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
    /// Interaction logic for MovieContainerControl.xaml
    /// </summary>
    public partial class MovieContainerControl : UserControl
    {
        Iconloader directories;
        private string genreName;
        public MovieContainerControl(String genreName)
        {
            InitializeComponent();
            string filepath = "Movies\\";
            this.directories = new Iconloader();
            this.directories.LoadDirectories(filepath);
            this.genreName = genreName;
            MakeIcons();
        }

        public MovieContainerControl()
        {
            InitializeComponent();
            string filepath = "Movies\\";
            this.directories = new Iconloader();
            this.directories.LoadDirectories(filepath);
            MakeIcons();
        }


        private void MakeIcons()
        {
            string[] thumbnails = this.directories.Directories;

            foreach(string path in thumbnails)
            {
                string newPath = path + MainWindowContoller.POSTER;
                try
                {
                    BitmapImage img = new BitmapImage(new Uri(newPath, UriKind.RelativeOrAbsolute));

                    MoreInfoIcon thumbnail = new MoreInfoIcon();
                    thumbnail.Close.Visibility = Visibility.Collapsed;
                    this.Genre.Text = this.genreName;
                    thumbnail.Icon.Source = img;
                    thumbnail.Description = directories.LoadDescription(path + MainWindowContoller.DESCRIPTION);
                    thumbnail.ButtonLabel.Content = directories.Title;
                    

                    // find the name of the file from the path
                    //                    photoTile.ImageTitle.Text = path.Split('\\').Last().Split('.').First();
                    // Subscribe to the PhotoTile's MouseDown event
                    //                    photoTile.MouseDown += new MouseButtonEventHandler(photoTile_MouseDown);
                    // Add the PhotoTile to the PhotoViewerGrid

                    //                thumbnail.Close.Visibility
                    thumbnail.MouseDown += Thumbnail_MouseDown;

                    Movies.UniformGrid.Children.Add(thumbnail);
                }
                catch(Exception e)
                {

                }
            }
        }

        private void Thumbnail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NetflixMain netflixMain = new NetflixMain();
            MoreInfoIcon thumbnail = (MoreInfoIcon)sender;
            netflixMain.MoviePoster.Source = thumbnail.Icon.Source;
            netflixMain.MovieDescription.Text = thumbnail.Description;
            netflixMain.MoreLike.Text = "More Like: " + thumbnail.ButtonLabel.Content.ToString();
            netflixMain.Title = thumbnail.ButtonLabel.Content.ToString();
            netflixMain.favouriteButtonCheck();
            //netflixMain.Title = (sender as MoreInfoIcon).Title;
            //netflixMain.image.Source = (sender as MoreInfoIcon).Image.Source;

            Navigation.NavigateTo(netflixMain);
        }
    }
}
