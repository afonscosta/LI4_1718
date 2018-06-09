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
        }

    
        public ActionResult AdicionarEncomendas()
        {
            //nome de utilizador que tem login feito
            var User_In_Session = User.Identity.Name;

            return View();
        }
    }
}