using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BreadSpread.Controllers
{
    public class SubscricaoController : Controller
    {
        // GET: Subscricao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdicionaEncomendas()
        {
            string user_authenticated = HttpContext.User.Identity.Name;
            return Redirect("/Home/Index");
        }
    }
}