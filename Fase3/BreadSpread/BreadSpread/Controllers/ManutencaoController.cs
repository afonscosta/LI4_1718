using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BreadSpread.Models;
using BreadSpread.Controllers;
using System.Net.Mail;

namespace BreadSpread.Controllers
{
    public class ManutencaoController : Controller
    {
        private BSContext db = new BSContext();

        public ActionResult AdminIndex()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");

            return View("~/Views/Admin/Index.cshtml");
        }

        public ActionResult Perfil()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");

            var User_In_Session = User.Identity.Name;

            var cliente = db.Clientes.Where(c => c.email.Equals(User_In_Session)).ToList();

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente[0]);
        }

        private void Send(Encomenda e)
        {
            using (MailMessage mm = new MailMessage("breadspread365@gmail.com", User.Identity.Name))
            {
                mm.Subject = "Confirmação de pagamento";
                mm.Body = "O presente email confirma que a encomenda número " + 
                           e.idEnc + " foi paga no dia " + e.dataPag + ".";
                mm.IsBodyHtml = false;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("breadspread365@gmail.com", "vamosfazerli4");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }
        }

        public ActionResult Paga(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");

            Encomenda e = db.Encomendas.Find(id);
            e.dataPag = DateTime.Now;
            e.modoPag = "online";
            e.estado = "confirmada";
            if (ModelState.IsValid)
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                Send(e);
            }

			return Redirect(Request.UrlReferrer.ToString());
		}

        public ActionResult DesativaCliente(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");

            Cliente c = db.Clientes.Find(id);
            c.estadoConta = "desativado";
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Logout", "Autenticacao");
        }

        public ActionResult PagaEncomendas(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");

            return View(db.Encomendas.Where(enc => enc.idCli.Equals(id) && 
                                            (enc.estado.Equals("pendente") || enc.estado.Equals("confirmada")) && 
                                            enc.dataPag == null)
                                     .ToList());
        }

        public ActionResult EditPerfil(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            var encomendas = db.Encomendas.Where(e => e.estado.Equals("pendente")).ToList();
            /*var encomendas = (from e in db.Encomendas
                            where e.estado == "pendente"
                            select e);*/

            return View(encomendas);
        }

        public ActionResult AceitarEncomenda(int? idEnc)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            return View(db.Produtoes.ToList());
        }

        // GET: Manutencao/Details/5
        public ActionResult DetailsProduto(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            return View();
        }

        // POST: Manutencao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduto([Bind(Include = "designacao,ingredientes,infoNutricional,preco,imagem,peso")] Produto produto)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            List<Funcionario> funcs = db.Funcionarios.Where(f => f.estadoConta.Equals("ativo")).ToList();

            return View(funcs);
        }

        // GET: Funcionarios/Details/5
        public ActionResult DetailsFuncionario(string id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFuncionario([Bind(Include = "idFunc,nome,dataNasc,contacto,rua,numPorta,codPostal,cidade,password,freguesia,estadoConta,distribuicao")] Funcionario funcionario)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");

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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            Funcionario funcionario = db.Funcionarios.Find(id);
            funcionario.estadoConta = "desativado";
            db.Entry(funcionario).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexFuncionario");
        }
    }
}
