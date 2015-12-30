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
    /// Interaction logic for dotsControl.xaml
    /// </summary>
    public partial class dotsControl : UserControl
    {
        public static  MainWindowContoller main;

        public dotsControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //pc 
            main.fromPC(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //sercive 
            main.addService(sender,e);

        }
    }
}
