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

using System.Windows.Threading;


namespace HTPC_Project
{
    /// <summary>
    /// Interaction logic for topBarMain.xaml
    /// </summary>
    public partial class topBarMain : UserControl
    {
        menuController menu = new menuController();

        public topBarMain()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
            
        void timer_Tick(object sender, EventArgs e)
        {
            timerText.Text = DateTime.Now.ToLongTimeString();
        }

        private void button_Copy3_Click(object sender, RoutedEventArgs e)
        {
            if (grid_MainBar.Children.Contains(menu))
            {
                grid_MainBar.Children.Remove(menu);
            }
            else
            {
                grid_MainBar.Children.Add(menu);
            }
        }

    }
}
