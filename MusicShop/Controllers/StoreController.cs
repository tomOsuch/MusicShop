using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicShop.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult List(string genrename)
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}