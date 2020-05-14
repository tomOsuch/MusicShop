using MusicShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicShop.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Album> Bestsellers { get; set; }
        public IEnumerable<Album> NewArivals { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

    }
}