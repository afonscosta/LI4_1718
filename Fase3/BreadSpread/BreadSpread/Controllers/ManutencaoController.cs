using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BreadSpread.Models;

namespace BreadSpread.Controllers
{
    public class ManutencaoController : Controller
    {
        private BSContext db = new BSContext();

        public ActionResult AdminIndex()
        {
            return View("~/Views/Admin/Index.cshtml");
        }

        //==============================
        //========= PRODUTOS ===========
        //==============================

        // GET: Manutencao
        public ActionResult IndexProduto()
        {
            return View(db.Produtoes.ToList());
        }

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
        public ActionResult DeleteConfirmedProduto(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            db.Produtoes.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("IndexProduto");
        }


        //==============================
        //======= FUNCIONARIOS =========
        //==============================

        // GET: Funcionarios
        public ActionResult IndexFuncionario()
        {
            List<Funcionario> funcs = db.Funcionarios.Where(f => f.estadoConta.Equals("ativo")).ToList();

            return View(funcs);
        }

        // GET: Funcionarios/Details/5
        public ActionResult DetailsFuncionario(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public ActionResult CreateFuncionario()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFuncionario([Bind(Include = "idFunc,nome,dataNasc,contacto,rua,numPorta,codPostal,cidade,password,freguesia,estadoConta,distribuicao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("IndexFuncionario");
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult EditFuncionario(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFuncionario([Bind(Include = "idFunc,nome,dataNasc,contacto,rua,numPorta,codPostal,cidade,password,freguesia,estadoConta,distribuicao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexFuncionario");
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult DeleteFuncionario(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("DeleteFuncionario")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedFuncionario(string id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            funcionario.estadoConta = "desativado";
            db.Entry(funcionario).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexFuncionario");
        }
    }
}
