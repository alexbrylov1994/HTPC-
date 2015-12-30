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
    /// Interaction logic for WatchPCMoviesDescription.xaml
    /// </summary>
    public partial class WatchPCMoviesDescription : UserControl
    {
       // topBar topbar = new topBar();
        public WatchPCMoviesDescription()
        {

            InitializeComponent();
        //    WatchPCMoviesDescription_Grid.Children.Add(topbar);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
