using MusicShop.DAL;
using MvcSiteMapProvider.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicShop.Controllers
{
    public class StoreController : Controller
    {
        StoreContext db = new StoreContext();
        // GET: Store

        public ActionResult Details(int id)
        {
            var album = db.Albums.Find(id);
            return View(album);
        }

        public ActionResult List(string genrename, string searchQuery = null)
        {
            var genre = db.Genres.Include("Albums").Where(g => g.Name.ToUpper() == genrename.ToUpper()).Single();
            var albums = genre.Albums.Where(a => (searchQuery == null || 
                                                  a.AlbumTitle.ToLower().Contains(searchQuery.ToLower()) ||
                                                  a.ArtistName.ToLower().Contains(searchQuery.ToLower())) && 
                                                  !a.IsHidden);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProductList", albums);
            }

            return View(albums);
        }

        public ActionResult AlbumsSuggestions(string term)
        {
            var albums = this.db.Albums.Where(a => a.AlbumTitle.ToLower().Contains(term.ToLower()) && !a.IsHidden).Take(5).Select(a => new { label = a.AlbumTitle });

            return Json(albums, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        [OutputCache(Duration = 86400)]
        public ActionResult GenresMenu()
        {
            var genres = db.Genres.ToList();

            return PartialView("_GenresMenu", genres);
        }
    }
}