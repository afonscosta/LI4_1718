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

        public ActionResult AdicionarProduto(Produto produto, int quantidade)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");

            else
            {
                Tuple<Produto, int> added = new Tuple<Produto, int>(produto, quantidade);

                List<Tuple<Produto, int>> aux = (List<Tuple<Produto, int>>)Session["Carrinho"];
                aux.Add(added);

                Session["Carrinho"] = aux;

                return RedirectToAction("Produtos", "Home");
            }
        }
    }
}