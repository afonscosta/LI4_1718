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

        public ActionResult AdicionarProduto(int idProd, String designacao, float preco, int? quant)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");

            else
            {
                if (quant == null)
                    quant = 1;

                Tuple<int, String, float, int> added = new Tuple<int, String, float, int>(idProd, designacao, preco, (int) quant);

                List<Tuple<int, String, float, int>> aux = (List<Tuple<int, String, float, int>>)Session["Carrinho"];
                aux.Add(added);

                Session["Carrinho"] = aux;

                float diff = (float)Session["Total"];
                diff += preco * (int)quant;

                Session["Total"] = diff;

                return RedirectToAction("Produtos", "Home");
            }
        }
    }
}