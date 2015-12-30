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
    /// Interaction logic for AreYouSure.xaml
    /// </summary>
    public partial class AreYouSure : UserControl
    {
        public string ans = "";

        public AreYouSure()
        {
            InitializeComponent();
        }

        private void no(object sender, RoutedEventArgs e)
        {
            ans = "no";
            this.Visibility = Visibility.Collapsed;
        }

        private void Yes(object sender, RoutedEventArgs e)
        {
            ans = "yes";
            this.Visibility = Visibility.Collapsed;
        }
    }
}
