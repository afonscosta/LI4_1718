using BreadSpread.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BreadSpread.Controllers
{
    public class HomeController : Controller
    {
        private BSContext db = new BSContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ComoFunciona()
        {
            return View();
        }

        public ActionResult Produtos()
        {
            return View(db.Produtoes.ToList());
        }
    }
}