using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HTPC_Project
{
    public static class Navigation
    {
        public static MainWindowContoller HomePage;

        public static Panel ContentContainer;

        private static Button backButton;
        public static Button BackButton
        {
            get
            {
                return backButton;
            }
            set
            {
                backButton = value;
                backButton.Click += BackButton_Click;
            }
        }

        private static Stack<UserControl> navStack = new Stack<UserControl>();

//        private static Stack<bool> isHomePageStack = new Stack<bool>();

        public static void NavigateTo(UserControl userControl)
        {
            if (ContentContainer.Children.Count == 1)  // if a page is loaded
            {
//                if (ContentContainer.Children[0].GetType() == typeof(MainWindowContoller))
//                {
//                    isHomePageStack.Push(true);
//                }
//                else
//                {
//                    isHomePageStack.Push(false);
                    navStack.Push(ContentContainer.Children[0] as UserControl);
//                }
                
                backButton.Visibility = Visibility.Visible;
                ContentContainer.Children.Clear();
            }

            ContentContainer.Children.Add(userControl);
        }

        private static void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.Children.Clear();

//            if (isHomePageStack.Pop() == true)
//            {
//                ContentContainer.Children.Add(HomePage);
//            }
//            else
//            {
                ContentContainer.Children.Add(navStack.Pop());
//            }

            if (navStack.Count() == 0/* && isHomePageStack.Count() == 0*/)
            {
                backButton.Visibility = Visibility.Collapsed;
            }
        }

        internal static void NavigateTo(ref NetflixMain netflixMain)
        {
            throw new NotImplementedException();
        }
    }
}