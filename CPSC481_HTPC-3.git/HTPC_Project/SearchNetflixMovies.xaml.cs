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
    /// Interaction logic for SearchNetflixMovies.xaml
    /// </summary>
    public partial class SearchNetflixMovies : UserControl
    {
        MoreInfoIcon newIcon;
        public MoreInfoIcon NewIcon
        {
            set
            {
                newIcon = value;
            }
        }
        public SearchNetflixMovies()
        {
            InitializeComponent();

            /*            foreach (MoreInfoIcon icon in MovieLists.ActionMovieList)
                        {
                            //Need to move descriptionn
                            //Title under icons
                            newIcon = new MoreInfoIcon();
                            newIcon.ButtonLabel = icon.ButtonLabel;
                            newIcon.Icon.Source = icon.Icon.Source;
                            newIcon.VisualIndicator = icon.VisualIndicator;
                            newIcon.Click = icon.Click;
                            newIcon.Description = icon.Description;
                            newIcon.Close.Visibility = Visibility.Collapsed;

                            //MoreInfoIcon newIcon = icon;
                        }*/

            unfavourite.Visibility = Visibility.Collapsed;
            favourite.Visibility = Visibility.Collapsed;


        }

        public void checkFavourites()
        {
            foreach (MoreInfoIcon checkIcon in MovieLists.FavouriteMovieList)
            {
                if (newIcon.ButtonLabel.Content.ToString() == checkIcon.ButtonLabel.Content.ToString())
                {
                    unfavourite.Visibility = Visibility.Visible;
                    favourite.Visibility = Visibility.Collapsed;
                    break;
                }
            }
            if (unfavourite.Visibility == Visibility.Collapsed)
            {
                favourite.Visibility = Visibility.Visible;
            }
            else
            {
                favourite.Visibility = Visibility.Collapsed;
            }
        }

        private void PlayButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MoviePlayBack playback = new MoviePlayBack();
            Navigation.NavigateTo(playback);
        }

        private void FavouriteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MovieLists.FavouriteMovieList.Add(this.newIcon);
            favourite.Visibility = Visibility.Collapsed;
            unfavourite.Visibility = Visibility.Visible;
        }

        private void UnfavouriteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                foreach (MoreInfoIcon icon in MovieLists.FavouriteMovieList)
                {
                    if (newIcon.ButtonLabel.Content.ToString() == icon.ButtonLabel.Content.ToString())
                    {
                        MovieLists.FavouriteMovieList.Remove(icon);
                    }
                }
            }
            catch (Exception e1)
            {
                //do nothing
            }
            unfavourite.Visibility = Visibility.Collapsed;
            favourite.Visibility = Visibility.Visible;
        }

        private void Overlay_Click(object sender, RoutedEventArgs e)
        {
            NetflixMain netflixMain = new NetflixMain();
            netflixMain.MoviePoster.Source = newIcon.Icon.Source;
            netflixMain.MovieDescription.Text = newIcon.Description;
            netflixMain.MoreLike.Text = "More like: " + newIcon.ButtonLabel.Content.ToString();
            netflixMain.favouriteButtonCheck();

            //netflixMain.Title = (sender as MoreInfoIcon).Title;
            //netflixMain.image.Source = (sender as MoreInfoIcon).Image.Source;

            Navigation.NavigateTo(netflixMain);
        }

    }
}
