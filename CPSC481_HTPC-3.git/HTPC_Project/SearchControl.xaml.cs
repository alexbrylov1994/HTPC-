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
    /// Interaction logic for SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl
    {
        public static MainWindowContoller main;

        public SearchControl()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }

        private void searchResultsUpdate()
        {
            foreach (MoreInfoIcon item in grid.Children)
            {
                if ( item.ButtonLabel.Content.ToString().ToLower().Contains(searchBox.Text.ToLower()))
                {
                    item.Visibility = Visibility.Visible;
                }
                else
                {
                    item.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchResultsUpdate();
        }
    }
}
