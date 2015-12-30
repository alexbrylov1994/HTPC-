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
    /// Interaction logic for MoviePlayBack.xaml
    /// </summary>
    public partial class MoviePlayBack : UserControl
    {
        //topBar topbar = new topBar();
        public MoviePlayBack()
        {
            InitializeComponent();
        //    grid.Children.Add(topbar);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateTo(new MusicPlayBack());
        }
    }
}
