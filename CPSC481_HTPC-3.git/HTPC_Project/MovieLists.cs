using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTPC_Project
{
    public static class MovieLists
    {
        private static ArrayList actionMovieList = new ArrayList();

        public static ArrayList ActionMovieList
        {
            get
            {
                return actionMovieList;
            }
        }

        private static ArrayList favouriteMovieList = new ArrayList();

        public static ArrayList FavouriteMovieList
        {
            get
            {
                return favouriteMovieList;
            }
        }



    }
}
