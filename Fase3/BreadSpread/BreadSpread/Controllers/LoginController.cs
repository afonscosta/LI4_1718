using BreadSpread.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BreadSpread.Controllers
{
    public class LoginController : Controller
    {
        BSContext db = new BSContext();
        // GET: Login
        public ActionResult Index()
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
            return RedirectToAction("Index", "Login");
        }
    }
}