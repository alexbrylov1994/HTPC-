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
    /// Interaction logic for SuscribeMessage.xaml
    /// </summary>
    public partial class SuscribeMessage : UserControl
    {
        public static menuController menu;

        public string netflix;

        public SuscribeMessage()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            (this.Parent as Panel).Children.Remove(this);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Button service = (Button)sender;

            if (netflix == "Netflix 1")
            {
                menu.button1.Visibility = Visibility.Collapsed;
                menu.exp1.Visibility = Visibility.Collapsed;
                menu.date1.Visibility = Visibility.Collapsed;
                menu.netflix1.Visibility = Visibility.Collapsed;
            }

            if (netflix == "Netflix 2")
            {
                menu.button2.Visibility = Visibility.Collapsed;
                menu.exp2.Visibility = Visibility.Collapsed;
                menu.date2.Visibility = Visibility.Collapsed;
                menu.netflix2.Visibility = Visibility.Collapsed;
            }

            if (netflix == "Netflix 3")
            {
                menu.button3.Visibility = Visibility.Collapsed;
                menu.exp3.Visibility = Visibility.Collapsed;
                menu.date3.Visibility = Visibility.Collapsed;
                menu.netflix3.Visibility = Visibility.Collapsed;
            }

            if (netflix == "Netflix 4")
            {
                menu.button4.Visibility = Visibility.Collapsed;
                menu.exp4.Visibility = Visibility.Collapsed;
                menu.date4.Visibility = Visibility.Collapsed;
                menu.netflix4.Visibility = Visibility.Collapsed;
            }

            (this.Parent as Panel).Children.Remove(this);
        }
    }
}
