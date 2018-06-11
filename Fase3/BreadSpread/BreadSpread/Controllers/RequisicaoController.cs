using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BreadSpread.Controllers
{
    public class RequisicaoController : Controller
    {
        // GET: Requisicao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Carrinho()
        {
            return View();
        }

        public ActionResult Subscrever()
        {
            return View();
        }

        public ActionResult Ocasional()
        {
            return View();
        }
    }
}