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
    /// Interaction logic for DeleteMessage.xaml
    /// </summary>
    public partial class DeleteMessage : UserControl
    {

        public static string text; // = (string)icon.Content;

        public MoreInfoIcon icon;

        public menuController menu;

        public DeleteMessage()
        {
            InitializeComponent();
        }

        public string set_message()
        {
            return ErrorMessage.Content + " " + text + "?";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            icon.Visibility = Visibility.Collapsed;
            try
            {
                foreach(MoreInfoIcon newIcon in MovieLists.FavouriteMovieList)
                {
                    if(icon.ButtonLabel.Content == newIcon.ButtonLabel.Content)
                    {
                        MovieLists.FavouriteMovieList.Remove(newIcon);
                    }
                }
            }
            catch
            {

            }
            (this.Parent as Panel).Children.Remove(this);
        }
    }
}
