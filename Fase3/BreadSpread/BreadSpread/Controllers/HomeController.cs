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

        public ActionResult AdicionarProduto(int idProd, int? quant)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");

            else
            {
                if (quant == null)
                    quant = 1;

                Tuple<int, int> added = new Tuple<int, int>(idProd, (int) quant);

                List<Tuple<int, int>> aux = (List<Tuple<int, int>>)Session["Carrinho"];
                aux.Add(added);

                Session["Carrinho"] = aux;

                return RedirectToAction("Produtos", "Home");
            }
        }
    }
}