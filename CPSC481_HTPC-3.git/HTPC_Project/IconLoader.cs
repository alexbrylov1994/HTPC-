using System;
using System.Collections.Generic;
using System.IO;
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
    class Iconloader
    {
        /// <summary>
        /// Loads Directories
        /// Courtesy of PicturOo
        /// </summary>
            private string[] directories = { };
            private string[] icons = { };

            private string title;
            public string Title
            {
                get
                {
                    return this.title;
                }
            }

            public string[] Directories
            {
                get
                {
                    return this.directories;
                }
            }
            public string[] Icons
            {
                get
                {
                    return this.icons;
                }
            }
            
            public void LoadDirectories(string path)
            {
            string[] thing;
            string fullDirectory = "..\\..\\" + path;//System.IO.Path.Combine(Directory.GetCurrentDirectory(), path);
                try
                {
                    directories = System.IO.Directory.GetDirectories(fullDirectory);
                    Console.WriteLine(directories);

                }
                catch (Exception)
                {
                //Do nothing
                String[] n = directories;
                    int x = 2;
                }
            }

        public void LoadFiles(string path)
        {
            string[] thing;
            string fullDirectory = "..\\..\\" + path;//System.IO.Path.Combine(Directory.GetCurrentDirectory(), path);
            try
            {
                directories = System.IO.Directory.GetFiles(fullDirectory);
                Console.WriteLine(directories);

            }
            catch (Exception)
            {
                //Do nothing
                String[] n = directories;
                int x = 2;
            }
        }

        public string LoadDescription(string path)
        {
            string description;
            TextReader file;
            Uri uri = new Uri(path, UriKind.RelativeOrAbsolute);
            string newPath = System.IO.Path.GetFullPath(path);
            int i = 0;


            try
            {
                file = new StreamReader(newPath);
                //                file = new StreamReader(newPath);
                title = file.ReadLine();
                description = file.ReadToEnd();
                return description;
            }
            catch (Exception)
            {
                //Do nothing
                int n = 1;
                int x = 2;
                return "Description not found\n";
            }

        }


    }

}
