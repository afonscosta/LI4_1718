using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BreadSpread.Models;

namespace BreadSpread.Controllers
{
    public class PesquisaController : Controller
    {
        private BSContext db = new BSContext();

        // GET: Pesquisa
        public ActionResult IndexProducao()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            var encomendas_hoje = new List<Encomenda_Produto>();
            if (encomendas_hoje.Count() == 0)
            {
                var encomendas = db.Encomenda_Produto.Where(ep => ep.Encomenda.estado.Equals("confirmada") && ep.estado.Equals("pendente")).ToList();
                encomendas_hoje = encomendas.Where(ep => ep.Encomenda.dataEnt.Date == DateTime.Now.Date).ToList();
            }
            return View(encomendas_hoje);
        }

        public ActionResult CheckProduto(int idEnc, int idProd)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            return RedirectToAction("CheckProduto", "Realizacao", new { idEnc, idProd });
        }

		
        // GET: Pesquisa/Details/5
        public ActionResult Details(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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

        // GET: Pesquisa/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            ViewBag.idCli = new SelectList(db.Clientes, "idCli", "nome");
            return View();
        }

        // POST: Pesquisa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEnc,idCli,dataEnt,custo,estado,idFunc,rua,numPorta,codPostal,cidade,obs,freguesia,tipoEnc,dataPag,modoPag,fatura")] Encomenda encomenda)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            if (ModelState.IsValid)
            {
                db.Encomendas.Add(encomenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCli = new SelectList(db.Clientes, "idCli", "nome", encomenda.idCli);
            return View(encomenda);
        }

        // GET: Pesquisa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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

        // POST: Pesquisa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEnc,idCli,dataEnt,custo,estado,idFunc,rua,numPorta,codPostal,cidade,obs,freguesia,tipoEnc,dataPag,modoPag,fatura")] Encomenda encomenda)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            if (ModelState.IsValid)
            {
                db.Entry(encomenda).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("IndexProducao");
            }
            ViewBag.idCli = new SelectList(db.Clientes, "idCli", "nome", encomenda.idCli);
            //return View(encomenda);
            return RedirectToAction("IndexProducao");
        }

        // GET: Pesquisa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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

        // POST: Pesquisa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            Encomenda encomenda = db.Encomendas.Find(id);
            db.Encomendas.Remove(encomenda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
