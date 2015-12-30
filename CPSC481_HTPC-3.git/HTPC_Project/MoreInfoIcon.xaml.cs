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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    /// 

    public partial class MoreInfoIcon : UserControl
    {
        public static MainWindowContoller main;
        DeleteMessage message;
        private string title;
        private bool isNetflixButton = false;

        public string Title
        {
            get
            {
                return this.title;
            }
        }

        private Image theIcon;
        public Image TheIcon
        {
            set
            {
                theIcon = value;
            }
            get
            {
                return theIcon;
            }
        }

        private string description;
        public string Description
        {
            set
            {
                description = value;
            }
            get
            {
                return description;
            }
        }

        public MoreInfoIcon()
        {
            InitializeComponent();

        }
        public MoreInfoIcon(bool isNetflixButton)
        {
            InitializeComponent();
            this.isNetflixButton = isNetflixButton;
        }

        /// <summary>
        /// What happens when you click on the icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            //this.Visibility = Visibility.Collapsed;
            //main.mainGrid.Children.

            //(this.Parent as Panel).Children.Add(message);
            message = new DeleteMessage();
            message.ErrorMessage.Content = message.ErrorMessage.Content + " " + ButtonLabel.Content.ToString() + "?";
            message.icon = this;
            main.mainGrid.Children.Add(message);
           // message.text = (string)ButtonLabel.Content


        }

    }
}
