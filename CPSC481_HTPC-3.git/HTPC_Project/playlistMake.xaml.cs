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
using System.Windows.Shapes;

namespace HTPC_Project
{
    /// <summary>
    /// Interaction logic for playlistMake.xaml
    /// </summary>
    public partial class playlistMake : Window
    {
        string playlistname, pstatus;

        public playlistMake()
        {
            InitializeComponent();
        }

        public string name
        {
            get { return playlistname; }
        }

        public string status
        {
            get { return pstatus; }
        }

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            playlistname = this.text.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pstatus = "ok";
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
