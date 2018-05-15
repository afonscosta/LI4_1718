using BreadSpread.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BreadSpread.Controllers
{
    public class RegistarController : Controller
    {
        ClientesContext db = new ClientesContext();

        // GET: Registar
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarCliente([Bind(Include = "idCli, nome, dataNasc, NIF, sexo, email, rua, numPorta,codPostal, cidade, ratingServico, contacto, freguesia,password,estadoConta,idSub")] Cliente cliente)
        {
            //if (ModelState.IsValid)
            //{
                db.Clientes.Add(cliente);
                db.SaveChanges();
            //}
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