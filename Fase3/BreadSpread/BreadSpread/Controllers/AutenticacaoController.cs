using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BreadSpread.Models;

namespace BreadSpread.Controllers
{
    public class AutenticacaoController : Controller
    {
        BSContext db = new BSContext();

        // GET: Autenticacao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistarIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autentica(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var clientes = (from c in db.Clientes
                    where c.email == username && c.password == password
                    select c);
                if (clientes.ToList<Cliente>().Count > 0)
                {
                    Cliente cliente = clientes.ToList<Cliente>().ElementAt<Cliente>(0);
                    FormsAuthentication.SetAuthCookie(cliente.email, false);
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Request");
            }

            return RedirectToAction("Index", "AutenticacaoController");
        }

        [HttpPost]
        public ActionResult AdicionarCliente(
            [Bind(Include =
                "idCli, nome, dataNasc, NIF, sexo, email, rua, numPorta,codPostal, cidade, ratingServico, contacto, freguesia,password,estadoConta,idSub")]
            Cliente cliente)
        {
            cliente.estadoConta = "ativo";
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
            return RedirectToAction("sucessOperation");
        }

        public ActionResult sucessOperation()
        {
            ViewBag.title = "Cliente adicionado com sucesso";
            ViewBag.mensagem = "Cliente inserido com sucesso";
            return View();
        }
    }
}