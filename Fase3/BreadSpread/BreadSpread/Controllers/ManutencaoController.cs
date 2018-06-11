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

        public ActionResult Perfil()
        {
            var User_In_Session = User.Identity.Name;

            var cliente = db.Clientes.Where(c => c.email.Equals(User_In_Session)).ToList();

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente[0]);
        }

        public ActionResult Paga(int id)
        {
            Encomenda e = db.Encomendas.Find(id);
            e.dataPag = System.DateTime.Now;
            e.modoPag = "online";
            db.Entry(e).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Perfil", "Manutencao");
        }

        public ActionResult DesativaCliente(int id)
        {
            Cliente c = db.Clientes.Find(id);
            c.estadoConta = "desativado";
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Logout", "Autenticacao");
        }

        public ActionResult PagaEncomendas(int id)
        {
            return View(db.Encomendas.Where(enc => enc.idCli.Equals(id) && enc.estado.Equals("pendente") && enc.dataPag == null).ToList());
        }

        public ActionResult EditPerfil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPerfil([Bind(Include = "idCli,nome,email,sexo,dataNasc,rua,freguesia,cidade,codPostal,numPorta,contacto,NIF, estado,password")] Cliente cliente)
        {
            cliente.estadoConta = "ativo";
            //DEIXEI ASSIM PORQUE COM O MODEL STATE NÃO DÁ (COMO ESTÁ INSERE CORRETAMENTE TUDO)
            //if (ModelState.IsValid)
            //{
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Perfil");
            //}
            return View(cliente);
        }

        public ActionResult Ocasionais()
        {
            var encomendas = db.Encomendas.Where(e => e.estado.Equals("pendente")).ToList();
            /*var encomendas = (from e in db.Encomendas
                            where e.estado == "pendente"
                            select e);*/

            return View(encomendas);
        }

        public ActionResult AceitarEncomenda(int? idEnc)
        {
            if (idEnc == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(idEnc);
            if (encomenda == null)
            {
                return HttpNotFound();
            }

            encomenda.estado = "confirmada";

            if (ModelState.IsValid)
            {
                db.Entry(encomenda).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Ocasionais");
        }

        public ActionResult RecusarEncomenda(int? idEnc)
        {
            if (idEnc == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(idEnc);
            if (encomenda == null)
            {
                return HttpNotFound();
            }

            //remoçºao da encomenda em si
            db.Encomendas.Remove(encomenda);

            //remoçºao de todas as entradas associadas à encomenda a remover
            var enc_rem = db.Encomenda_Produto.Where(e => e.idEnc == idEnc).ToList();
            foreach (var m in enc_rem)
                db.Encomenda_Produto.Remove(m);

            db.SaveChanges();

            return RedirectToAction("Ocasionais");
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
