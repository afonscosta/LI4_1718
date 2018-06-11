using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BreadSpread.Models;

namespace BreadSpread.Controllers
{
    public class SubscricaoController : Controller
    {

        private BSContext db = new BSContext();
        // GET: Subscricao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubBronze()
        {
            return View();
        }
        public ActionResult SubBronzeProdutos()
        {
            return View(db.Produtoes.ToList());
        }

        public ActionResult CreateEncomendas(bool dia1, bool dia2, bool dia3, bool dia4, bool dia5)
        {
            TimeSpan hour = new TimeSpan(7, 0, 0);
            DateTime data1 = DateTime.MinValue;
            DateTime data2 = DateTime.MinValue;
            DateTime data3 = DateTime.MinValue;
            DateTime data4 = DateTime.MinValue;
            DateTime data5 = DateTime.MinValue;
            if(dia1)
            {
                data1 = DateTime.Now;
                data1 = data1.Date + hour;
            }
            if(dia2)
            {
                data2 = DateTime.Now.AddDays(1);
                data2 = data2.Date + hour;
            }
            if(dia3)
            {
                data3 = DateTime.Now.AddDays(2);
                data3 = data3.Date + hour;
            }
            if(dia4)
            {
                data4 = DateTime.Now.AddDays(3);
                data4 = data4.Date + hour;
            }
            if(dia5)
            {
                data5 = DateTime.Now.AddDays(4);
                data5 = data5.Date + hour;
            }
            var user_mail = System.Web.HttpContext.Current.User.Identity.Name;
            var cliente = db.Clientes.Where(c => c.email.Equals(user_mail) && c.estadoConta.Equals("ativo")).ToList()[0];

            Encomenda encomenda1 = null;
            Encomenda encomenda2 = null;
            Encomenda encomenda3 = null;
            Encomenda encomenda4 = null;
            Encomenda encomenda5 = null;

            if (data1.CompareTo(DateTime.MinValue) != 0)
            {
                encomenda1 = new Encomenda();
                encomenda1.idCli = cliente.idCli;
                encomenda1.dataEnt = data1;
                encomenda1.custo = 0;
                encomenda1.estado = "pendente";
                encomenda1.idFunc = "E001";
                encomenda1.rua = cliente.rua;
                encomenda1.numPorta = cliente.numPorta;
                encomenda1.codPostal = cliente.codPostal;
                encomenda1.cidade = cliente.cidade;
                encomenda1.obs = null;
                encomenda1.freguesia = cliente.freguesia;
                encomenda1.tipoEnc = "regular";
                encomenda1.dataPag = null;
                encomenda1.modoPag = null;
                encomenda1.fatura = null;
                if (ModelState.IsValid)
                {
                    db.Encomendas.Add(encomenda1);
                    db.SaveChanges();
                }
            }

            if (data2.CompareTo(DateTime.MinValue) != 0)
            {
                encomenda2 = new Encomenda();
                encomenda2.idCli = cliente.idCli;
                encomenda2.dataEnt = data2;
                encomenda2.custo = 0;
                encomenda2.estado = "pendente";
                encomenda2.idFunc = "E001";
                encomenda2.rua = cliente.rua;
                encomenda2.numPorta = cliente.numPorta;
                encomenda2.codPostal = cliente.codPostal;
                encomenda2.cidade = cliente.cidade;
                encomenda2.obs = null;
                encomenda2.freguesia = cliente.freguesia;
                encomenda2.tipoEnc = "regular";
                encomenda2.dataPag = null;
                encomenda2.modoPag = null;
                encomenda2.fatura = null;
                if (ModelState.IsValid)
                {
                    db.Encomendas.Add(encomenda2);
                    db.SaveChanges();
                }
            }

            if (data3.CompareTo(DateTime.MinValue) != 0)
            {
                encomenda3 = new Encomenda();
                encomenda3.idCli = cliente.idCli;
                encomenda3.dataEnt = data3;
                encomenda3.custo = 0;
                encomenda3.estado = "pendente";
                encomenda3.idFunc = "E001";
                encomenda3.rua = cliente.rua;
                encomenda3.numPorta = cliente.numPorta;
                encomenda3.codPostal = cliente.codPostal;
                encomenda3.cidade = cliente.cidade;
                encomenda3.obs = null;
                encomenda3.freguesia = cliente.freguesia;
                encomenda3.tipoEnc = "regular";
                encomenda3.dataPag = null;
                encomenda3.modoPag = null;
                encomenda3.fatura = null;
                if (ModelState.IsValid)
                {
                    db.Encomendas.Add(encomenda3);
                    db.SaveChanges();
                }
            }

            if (data4.CompareTo(DateTime.MinValue) != 0)
            {
                encomenda4 = new Encomenda();
                encomenda4.idCli = cliente.idCli;
                encomenda4.dataEnt = data4;
                encomenda4.custo = 0;
                encomenda4.estado = "pendente";
                encomenda4.idFunc = "E001";
                encomenda4.rua = cliente.rua;
                encomenda4.numPorta = cliente.numPorta;
                encomenda4.codPostal = cliente.codPostal;
                encomenda4.cidade = cliente.cidade;
                encomenda4.obs = null;
                encomenda4.freguesia = cliente.freguesia;
                encomenda4.tipoEnc = "regular";
                encomenda4.dataPag = null;
                encomenda4.modoPag = null;
                encomenda4.fatura = null;
                if (ModelState.IsValid)
                {
                    db.Encomendas.Add(encomenda4);
                    db.SaveChanges();
                }
            }

            if (data5.CompareTo(DateTime.MinValue) != 0)
            {
                encomenda5 = new Encomenda();
                encomenda5.idCli = cliente.idCli;
                encomenda5.dataEnt = data5;
                encomenda5.custo = 0;
                encomenda5.estado = "pendente";
                encomenda5.idFunc = "E001";
                encomenda5.rua = cliente.rua;
                encomenda5.numPorta = cliente.numPorta;
                encomenda5.codPostal = cliente.codPostal;
                encomenda5.cidade = cliente.cidade;
                encomenda5.obs = null;
                encomenda5.freguesia = cliente.freguesia;
                encomenda5.tipoEnc = "regular";
                encomenda5.dataPag = null;
                encomenda5.modoPag = null;
                encomenda5.fatura = null;
                if (ModelState.IsValid)
                {
                    db.Encomendas.Add(encomenda5);
                    db.SaveChanges();
                }
            }

            Hashtable encs = new Hashtable();

            if (encomenda1 != null)
                encs.Add("enc1", encomenda1);
            if (encomenda2 != null)
                encs.Add("enc2", encomenda2);
            if (encomenda3 != null)
                encs.Add("enc3", encomenda3);
            if (encomenda4 != null)
                encs.Add("enc4", encomenda4);
            if (encomenda5 != null)
                encs.Add("enc5", encomenda5);

            HttpContext.Session.Add("encs", encs);

            return RedirectToAction("SubBronzeProdutos");
        }

        public ActionResult AddProdutos(int num_enc, string produto, int quantidade)
        {
            string[] words = produto.Split('-');

            string key_enc = null;

            if (num_enc == 1)
                key_enc = "enc1";
            if (num_enc == 2)
                key_enc = "enc2";
            if (num_enc == 3)
                key_enc = "enc3";
            if (num_enc == 4)
                key_enc = "enc4";
            if (num_enc == 5)
                key_enc = "enc5";

            if(((Hashtable) HttpContext.Session["encs"]).ContainsKey(key_enc))
            {
                Encomenda enc = (Encomenda) ((Hashtable)HttpContext.Session["encs"])[key_enc];
                double preco = db.Produtoes.Find(Int32.Parse(words[0])).preco;
                Encomenda enc_db = db.Encomendas.Find(enc.idEnc);
                enc_db.custo = enc_db.custo + preco * quantidade;
                Encomenda_Produto enc_prod = new Encomenda_Produto
                {
                    idEnc = enc.idEnc,
                    idProd = Int32.Parse(words[0]),
                    quant = quantidade,
                    estado = "pendente"
                };
                if (ModelState.IsValid)
                {
                    db.Entry(enc_db).State = EntityState.Modified;
                    db.Encomenda_Produto.Add(enc_prod);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("SubBronzeProdutos");
        }
        public ActionResult RemoveAllEncomendas()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SubPrata()
        {
            return View();
        }

        public ActionResult SubOuro()
        {
            return View();
        }

    
        public ActionResult AdicionarEncomendas()
        {
            //nome de utilizador que tem login feito
            var User_In_Session = User.Identity.Name;

            return View();
        }
    }
}