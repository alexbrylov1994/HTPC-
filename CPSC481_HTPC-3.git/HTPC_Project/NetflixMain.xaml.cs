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
    /// Interaction logic for NetflixMain.xaml
    /// </summary>
    public partial class NetflixMain : UserControl
    {
        // topBar topbar = new topBar();
        // MoviePlayBack movie = new MoviePlayBack();
        MoreInfoIcon newIcon;
        string title;

        public string Title
        {
            set
            {
                title = value;
            }
            get
            {
                return title;
            }
        }

        public NetflixMain()
        {
            InitializeComponent();
            string newTitle = title;

            foreach (MoreInfoIcon icon in MovieLists.ActionMovieList)
            {
                //Need to move description
                //Title under icons
                newIcon = new MoreInfoIcon();
                newIcon.ButtonLabel.Content = icon.ButtonLabel.Content;
                newIcon.ButtonLabel.Foreground = System.Windows.Media.Brushes.White;
                newIcon.ButtonLabel.Opacity = 0.25;
                newIcon.Icon.Source = icon.Icon.Source;
                newIcon.VisualIndicator = icon.VisualIndicator;
                newIcon.Click = icon.Click;
                newIcon.Description = icon.Description;
                newIcon.Close.Visibility = Visibility.Collapsed;
                newIcon.MouseDown += NewIcon_MouseDown;

                Suggestions.Children.Add(newIcon);

                //MoreInfoIcon newIcon = icon;

            }

            UnfavouriteButton.Visibility = Visibility.Collapsed;
            FavouriteButton.Visibility = Visibility.Collapsed;


            /*            {
                            FavouriteButton.Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            UnfavouriteButton.Visibility = Visibility.Collapsed;
                        }*/
            //   grid.Children.Add(topbar);
        }

        public void favouriteButtonCheck()
        {
            foreach (MoreInfoIcon checkIcon in MovieLists.FavouriteMovieList)
            {
                if (this.title == checkIcon.ButtonLabel.Content.ToString())
                {
                    UnfavouriteButton.Visibility = Visibility.Visible;
                    FavouriteButton.Visibility = Visibility.Collapsed;
                    break;
                }
            }
            if (UnfavouriteButton.Visibility == Visibility.Collapsed)
            {
                FavouriteButton.Visibility = Visibility.Visible;
            }
            else
            {
                FavouriteButton.Visibility = Visibility.Collapsed;
            }
        }

        private void NewIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NetflixMain netflixMain = new NetflixMain();
            MoreInfoIcon thumbnail = (MoreInfoIcon)sender;
            netflixMain.MoviePoster.Source = thumbnail.Icon.Source;
            netflixMain.MovieDescription.Text = thumbnail.Description;
            netflixMain.MoreLike.Text = "More Like: " + thumbnail.ButtonLabel.Content.ToString();
            netflixMain.Title = thumbnail.ButtonLabel.Content.ToString();
            string newTitle = netflixMain.Title;
            netflixMain.favouriteButtonCheck();
            Navigation.NavigateTo(netflixMain);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateTo(new MoviePlayBack());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateTo(new MainWindowContoller());
        }

        private void FavouriteButton_Click(object sender, RoutedEventArgs e)
        {
            MoreInfoIcon icon = new MoreInfoIcon();
            icon.Icon.Source = MoviePoster.Source;
            icon.ButtonLabel.Content = this.title;
            icon.MouseDown += NewIcon_MouseDown;
            icon.Description = MovieDescription.Text;

            MovieLists.FavouriteMovieList.Add(icon);
            UnfavouriteButton.Visibility = Visibility.Visible;
            FavouriteButton.Visibility = Visibility.Collapsed;
        }

        private void UnfavouriteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (MoreInfoIcon checkIcon in MovieLists.FavouriteMovieList)
                {
                    if (this.title == checkIcon.ButtonLabel.Content.ToString())
                    {
                        MovieLists.FavouriteMovieList.Remove(checkIcon);
                    }
                }
            }
            catch
            {
                //do nothing
            }

            FavouriteButton.Visibility = Visibility.Visible;
            UnfavouriteButton.Visibility = Visibility.Collapsed;
        }
    }
}
