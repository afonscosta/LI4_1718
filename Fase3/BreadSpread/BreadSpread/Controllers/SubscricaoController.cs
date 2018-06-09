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

            return View();
        }

        [HttpPost]
        public void adicionaEnc([Bind(Include =
                "idCli, dataEnt, custo, estado, idFunc, rua, numPorta, cosPostal, cidade, obs, freguesia, tipoEnc, dataPag, modoPag, fatura")]
            Encomenda encomenda)
        {

            //nome de utilizador que tem login feito
            var User_In_Session = User.Identity.Name;

            var encomendas = (from m in db.Encomendas
                              where m.idCli.ToString() == User_In_Session
                              select m);

            int lastEncID = encomendas.Max(item => item.idEnc);

            //inserir associação entre a encomenda e os produtos
            //adicionaProdEnc(produtos);
        }

        public void adicionaProdEnc(List<Tuple<int, int>> produtos, int lastEncID)
        {
            int tamanho_list = produtos.Count;
            for (int i = 0; i < tamanho_list; i++)
            {
                var enc_prod = new Encomenda_Produto();
                enc_prod.idEnc = lastEncID;
                enc_prod.idProd = produtos[i].Item1;
                enc_prod.quant = produtos[i].Item2;

                db.Encomenda_Produto.Add(enc_prod);
                db.SaveChanges();

            }
        }
    }
}