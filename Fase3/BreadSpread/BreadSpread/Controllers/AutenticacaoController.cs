using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BreadSpread.Encriptacao;
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
        public ActionResult Autentica(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var clientes = (from m in db.Clientes
                    where m.email == email
                    select m);
                if (clientes.ToList<Cliente>().Count > 0)
                {
                    Cliente cliente = clientes.ToList<Cliente>().ElementAt<Cliente>(0);
                    using (MD5 md5Hash = MD5.Create())
                    {
                        if (MyHelpers.VerifyMd5Hash(md5Hash, password, cliente.password))
                        {
                            FormsAuthentication.SetAuthCookie(cliente.email, false);
                        }
                        else
                        {
                            ModelState.AddModelError("password", "Password incorreta!");
                            return View("Index");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                    return View("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Request");
                return View("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Autentica", "Autenticacao");
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult AdicionarCliente(
            [Bind(Include =
                "nome, dataNasc, NIF, sexo, email, rua, numPorta, codPostal, cidade, contacto, freguesia,password,estadoConta")]
            Cliente cliente)
        {
            cliente.estadoConta = "ativo";
            if (ModelState.IsValid)
            {
                cliente.password = MyHelpers.HashPassword(cliente.password);
                db.Clientes.Add(cliente);
                db.SaveChanges();
				return RedirectToAction("sucessOperation");
			}
			return RedirectToAction("notsucessOperation");
        }

        public ActionResult sucessOperation()
        {
            ViewBag.title = "Cliente adicionado com sucesso";
            ViewBag.mensagem = "Cliente inserido com sucesso";
            return View();
        }
		public ActionResult notsucessOperation()
		{
			ViewBag.title = "Cliente não adicionado com sucesso";
			ViewBag.mensagem = "Cliente não inserido com sucesso";
			return View();
		}
	}
}
