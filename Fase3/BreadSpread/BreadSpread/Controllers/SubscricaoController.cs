using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BreadSpread.Models;

namespace BreadSpread.Controllers
{
    public class SubscricaoController : Controller
    {
        private BSContext db = new BSContext();
        // GET: Subscricao
        public ActionResult Index()
        {
            return View();
        }

<<<<<<< HEAD
        public ActionResult AdicionaEncomendas()
        {
            string user_authenticated = HttpContext.User.Identity.Name;
            return Redirect("/Home/Index");
=======
        public ActionResult SubBronze()
        {
            return View(db.Produtoes.ToList());
        }

        public ActionResult SubPrata()
        {
            return View();
        }

        public ActionResult SubOuro()
        {
            return View();
>>>>>>> 8a1ca7895bd6521280df26d3da4d6c1b2536600a
        }
    }
}