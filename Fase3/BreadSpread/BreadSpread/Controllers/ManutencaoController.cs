using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BreadSpread.Models;
using BreadSpread.Controllers;

namespace BreadSpread.Controllers
{
    public class ManutencaoController : Controller
    {
        private BSContext db = new BSContext();

        // GET: Manutencao
        public ActionResult IndexProduto()
        {
            return View(db.Produtoes.ToList());
        }

        public ActionResult AdminIndex()
        {
            return View("~/Views/Admin/Index.cshtml");
        }

        //public ActionResult ProdutosIndex()
        //{
        //    return RedirectToAction("Index", "Produto", new { view = "~/Views/Manutencao/Index.cshtml" });
        //}
        //public ActionResult ProdutosCreate()
        //{
        //    return RedirectToAction("Create", "Produto", new { view = "~/Views/Manutencao/Create.cshtml" });
        //}

        //public ActionResult ProdutosEdit()
        //{
        //    return RedirectToAction("Edit", "Produto", new { view = "~/Views/Manutencao/Edit.cshtml" });
        //}

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DesativarFuncionario([Bind(Include = "idFunc, nome, dataNasc, contacto, rua, numPorta, codPostal, cidade, password, freguesia, estadoConta, distribuicao")] Funcionario funcionario)
        {
            funcionario.estadoConta = "desativado";
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }
        */

        // GET: Manutencao/Details/5
        public ActionResult DetailsProduto(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Manutencao/Create
        public ActionResult CreateProduto()
        {
            return View();
        }

        // POST: Manutencao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduto([Bind(Include = "designacao,ingredientes,infoNutricional,preco,imagem,peso")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtoes.Add(produto);
                db.SaveChanges();
                return RedirectToAction("IndexProduto");
            }

            return View(produto);
        }

        // GET: Manutencao/Edit/5
        public ActionResult EditProduto(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Manutencao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduto([Bind(Include = "idProd,designacao,ingredientes,infoNutricional,preco,imagem,peso")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexProduto");
            }
            return View(produto);
        }

        // GET: Manutencao/Delete/5
        public ActionResult DeleteProduto(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Manutencao/Delete/5
        [HttpPost, ActionName("DeleteProduto")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            db.Produtoes.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("IndexProduto");
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
