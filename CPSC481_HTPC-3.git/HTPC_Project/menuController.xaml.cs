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
    /// Interaction logic for menuController.xaml
    /// </summary>
    public partial class menuController : UserControl
    {
        SuscribeMessage message;

        public menuController()
        {
            InitializeComponent();
            SuscribeMessage.menu = this;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {


            /*
            button1.Visibility = Visibility.Collapsed;
            exp1.Visibility = Visibility.Collapsed;
            date1.Visibility = Visibility.Collapsed;
            netflix1.Visibility = Visibility.Collapsed;*/
            message = new SuscribeMessage();

            message.netflix = netflix1.Content.ToString();

            grid.Children.Add(message);

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            /*
            button2.Visibility = Visibility.Collapsed;
            exp2.Visibility = Visibility.Collapsed;
            date2.Visibility = Visibility.Collapsed;
            netflix2.Visibility = Visibility.Collapsed;
            */
            message = new SuscribeMessage();
            message.netflix = netflix2.Content.ToString();
            grid.Children.Add(message);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            /* button3.Visibility = Visibility.Collapsed;
             exp3.Visibility = Visibility.Collapsed;
             date3.Visibility = Visibility.Collapsed;
             netflix3.Visibility = Visibility.Collapsed;
             */
            message = new SuscribeMessage();
            message.netflix = netflix3.Content.ToString();
            grid.Children.Add(message);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            /*
            button4.Visibility = Visibility.Collapsed;
            exp4.Visibility = Visibility.Collapsed;
            date4.Visibility = Visibility.Collapsed;
            netflix4.Visibility = Visibility.Collapsed;
            */
            message = new SuscribeMessage();
            message.netflix = netflix4.Content.ToString();
            grid.Children.Add(message);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow.SystemStatus(true);
            //MainWindow.SystemOff = true;
            MainWindow.TurnOff();
        }
    }
}
