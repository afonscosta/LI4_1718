using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
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
            string pattern = @"^[eap][0-9]{3}$";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            if (ModelState.IsValid)
            {
                if (rgx.IsMatch(email))
                {
                    var funcs = (from m in db.Funcionarios
                                 where m.idFunc == email && m.estadoConta != "desativado"
                                 select m);
                    if (funcs.ToList<Funcionario>().Count > 0)
                    {
                        Funcionario func = funcs.ToList<Funcionario>().ElementAt<Funcionario>(0);
                        using (MD5 md5Hash = MD5.Create())
                        {
                            if (MyHelpers.VerifyMd5Hash(md5Hash, password, func.password))
                            {
                                FormsAuthentication.SetAuthCookie(func.idFunc.ToString(), false);
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
                    var clientes = (from m in db.Clientes
                                    where m.email == email && m.estadoConta != "desativado"
                                    select m);
                    if (clientes.ToList<Cliente>().Count > 0)
                    {
                        Cliente cliente = clientes.ToList<Cliente>().ElementAt<Cliente>(0);
                        using (MD5 md5Hash = MD5.Create())
                        {
                            if (MyHelpers.VerifyMd5Hash(md5Hash, password, cliente.password))
                            {
                                FormsAuthentication.SetAuthCookie(cliente.email, false);
                                Session["Carrinho"] = new List<Tuple<Produto, int>>();
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
            }
            else
            {
                ModelState.AddModelError("", "Invalid Request");
                return View("Index");
            }
            if (rgx.IsMatch(email)) // É um funcionário
            {
                if (email[0] == 'A' || email[0] == 'a') // Administrador
                    return RedirectToAction("AdminIndex", "Manutencao");
                    //return RedirectToAction("IndexAdmin", "Manutencao");
                if (email[0] == 'E' || email[0] == 'e') // Estafeta
                    return View("~/Views/Estafeta/Index.cshtml");
                    //return RedirectToAction("Index", "Estafeta");
                if (email[0] == 'P' || email[0] == 'p') // Padeiro
                    return View("~/Views/Padeiro/Index.cshtml");
                    //return RedirectToAction("Index", "Padeiro");
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
                var originalPass = cliente.password;
                cliente.password = MyHelpers.HashPassword(cliente.password);
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return Autentica(cliente.email, originalPass);
            }
			return RedirectToAction("notsucessOperation");
        }

        public bool isAutenticado()
        {
            return (System.Web.HttpContext.Current.User != null) &&
                   System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        }
        

    }
}
