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
    /// Interaction logic for InstalServices.xaml
    /// </summary>
    public partial class InstalServices : UserControl
    {

        public static MainWindowContoller main;

        public InstalServices()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            scroll.Visibility = Visibility.Collapsed;

            installGrid.Visibility = Visibility.Visible;
            backButton.Visibility = Visibility.Visible;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {

            scroll.Visibility = Visibility.Visible;
            grid.Visibility = Visibility.Visible;
            installGrid.Visibility = Visibility.Collapsed;
            backButton.Visibility = Visibility.Collapsed;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            scroll.Visibility = Visibility.Visible;
            grid.Visibility = Visibility.Visible;
            installGrid.Visibility = Visibility.Collapsed;
            backButton.Visibility = Visibility.Collapsed;
        }

        private void install(object sender, RoutedEventArgs e)
        {
            main.addService_Click(sender, e);
        }
    }
}
