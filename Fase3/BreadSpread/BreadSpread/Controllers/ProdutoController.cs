using BreadSpread.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BreadSpread.Controllers
{
    public class ProdutoController : Controller
    {
        private BSContext db = new BSContext();

        // GET: Produto
        public ActionResult Index(string view)
        {
            return View(view, db.Produtoes.ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produto/Create
        public ActionResult Create(string view)
        {
            return View(view);
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(string view, [Bind(Include = "idProd,designacao,ingredientes,infoNutricional,preco,imagem,peso")] Produto produto)
        {
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                db.Produtoes.Add(produto);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Index", "Produto", new { view = "~/Views/Manutencao/Index.cshtml" });
            }
            return View();
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
