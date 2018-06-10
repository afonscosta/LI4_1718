using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BreadSpread.Models;

namespace BreadSpread.Controllers
{
    public class RealizacaoController : Controller
    {
        private BSContext db = new BSContext();

        public ActionResult PadeiroIndex()
        {
            return View("~/Views/Padeiro/Index.cshtml");
        }


        public ActionResult CheckProduto(int idEnc, int idProd)
        {
            var enc_prod_atual = db.Encomenda_Produto.Find(idEnc, idProd);
            if (enc_prod_atual != null)
            {
                enc_prod_atual.estado = "feito";
                if (ModelState.IsValid)
                {
                    db.Entry(enc_prod_atual).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            var encomendas = db.Encomenda_Produto.Where(ep => ep.Encomenda.estado.Equals("confirmada") && 
                                                              ep.idEnc == idEnc && 
                                                              ep.estado.Equals("espera"))
                                                 .ToList();
            var num_encomendas_hoje = encomendas.Where(ep => ep.Encomenda.dataEnt.Date == DateTime.Now.Date ).ToList().Count;

            if (num_encomendas_hoje == 0)
            {
                Encomenda encomenda = db.Encomendas.Find(idEnc);
                if (encomenda == null)
                {
                    return RedirectToAction("IndexProducao", "Pesquisa");
                }
                encomenda.estado = "confecionada";
                if (ModelState.IsValid)
                {
                    db.Entry(encomenda).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("IndexProducao", "Pesquisa");
        }
















        //// GET: Realizacao
        //public ActionResult IndexProducao()
        //{
        //    var encomendas = db.Encomendas.Include(e => e.Cliente);
        //    return View(encomendas.ToList());
        //}

        // GET: Realizacao/Details/5
        public ActionResult DetailsEncomenda(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        // GET: Realizacao/Create
        public ActionResult CreateEncomenda()
        {
            ViewBag.idCli = new SelectList(db.Clientes, "idCli", "nome");
            return View();
        }

        // POST: Realizacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEncomenda([Bind(Include = "idEnc,idCli,dataEnt,custo,estado,idFunc,rua,numPorta,codPostal,cidade,obs,freguesia,tipoEnc,dataPag,modoPag,fatura")] Encomenda encomenda)
        {
            if (ModelState.IsValid)
            {
                db.Encomendas.Add(encomenda);
                db.SaveChanges();
                return RedirectToAction("IndexEncomenda");
            }

            ViewBag.idCli = new SelectList(db.Clientes, "idCli", "nome", encomenda.idCli);
            return View(encomenda);
        }

        // GET: Realizacao/Edit/5
        public ActionResult EditEncomenda(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCli = new SelectList(db.Clientes, "idCli", "nome", encomenda.idCli);
            return View(encomenda);
        }

        // POST: Realizacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEncomenda([Bind(Include = "idEnc,idCli,dataEnt,custo,estado,idFunc,rua,numPorta,codPostal,cidade,obs,freguesia,tipoEnc,dataPag,modoPag,fatura")] Encomenda encomenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encomenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexEncomenda");
            }
            ViewBag.idCli = new SelectList(db.Clientes, "idCli", "nome", encomenda.idCli);
            return View(encomenda);
        }

        // GET: Realizacao/Delete/5
        public ActionResult DeleteEncomenda(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        // POST: Realizacao/Delete/5
        [HttpPost, ActionName("DeleteEncomenda")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedEncomenda(int id)
        {
            Encomenda encomenda = db.Encomendas.Find(id);
            db.Encomendas.Remove(encomenda);
            db.SaveChanges();
            return RedirectToAction("IndexEncomenda");
        }
    }
}
