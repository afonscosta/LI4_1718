using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web.Mvc;
using BreadSpread.Models;
using BingMapsRESTToolkit;
using System.IO;
using System.Text;
using System.Collections;

namespace BreadSpread.Controllers
{
    public class LatLong
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class RealizacaoController : Controller
    {
        private BSContext db = new BSContext();

        public ActionResult PadeiroIndex()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            return View("~/Views/Padeiro/Index.cshtml");
        }

        public ActionResult EstafetaIndex()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            return View("~/Views/Estafeta/Index.cshtml");
        }

        public ActionResult RegistaEntrega(int idEnc)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            Encomenda enc_db = db.Encomendas.Find(idEnc);
            enc_db.estado = "entregue";
            if (ModelState.IsValid)
            {
                db.Entry(enc_db).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Percurso");
        }
        public ActionResult CancelaEntrega(int idEnc, string obs)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            Encomenda enc_db = db.Encomendas.Find(idEnc);
            enc_db.estado = "falhada";
            enc_db.obs = obs;
            if (ModelState.IsValid)
            {
                db.Entry(enc_db).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Percurso");
        }

        public static LatLong Geocode(string address)
        {
            string url = "http://dev.virtualearth.net/REST/v1/Locations?query=" + address + "&key=Arf-w6Z0c3_4-bcaAuGaelwSAFWNaomV1EN1N7PG18GbR5raQUIhfeswUtFi6_Ze";

            using (var client = new WebClient())
            {
                string response = client.DownloadString(url);
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
                using (var es = new MemoryStream(Encoding.Unicode.GetBytes(response)))
                {
                    var mapResponse = (ser.ReadObject(es) as Response); //Response is one of the Bing Maps DataContracts
                    Location location = (Location)mapResponse.ResourceSets.First().Resources.First();
                    return new LatLong()
                    {
                        Latitude = location.Point.Coordinates[0],
                        Longitude = location.Point.Coordinates[1]
                    };
                }
            }
        }

        public ActionResult Percurso()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");

            var encomendas = db.Encomendas.Where(e => e.estado.Equals("confecionada") &&
                                                      e.dataPag != null)
                                          .ToList();
            var encomendas_hoje = encomendas.Where(e => e.dataEnt.Date == DateTime.Now.Date).ToList();

            var coordsLat = new ArrayList();
            var coordsLon = new ArrayList();
            var labelEncs = new ArrayList();

            foreach(var enc in encomendas_hoje)
            {
                LatLong coord = Geocode(enc.Cliente.rua + "," +
                                        enc.Cliente.numPorta + "," +
                                        enc.Cliente.freguesia + "," +
                                        enc.Cliente.codPostal + "," +
                                        enc.Cliente.cidade + ", Portugal");
                coordsLat.Add(coord.Latitude);
                coordsLon.Add(coord.Longitude);
                labelEncs.Add(enc.idEnc);
            }

            ViewBag.coordsLat = coordsLat;
            ViewBag.coordsLon = coordsLon;
            ViewBag.labelEncs = labelEncs;

            return View(encomendas_hoje);
        }


        public ActionResult CheckProduto(int idEnc, int idProd)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            var enc_prod_atual = db.Encomenda_Produto.Find(idEnc, idProd);
            if (enc_prod_atual != null)
            {
                enc_prod_atual.estado = "feito";
                if (ModelState.IsValid)
                {
                    db.Entry(enc_prod_atual).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            var encomendas = db.Encomenda_Produto.Where(ep => ep.Encomenda.estado.Equals("confirmada") && 
                                                              ep.Encomenda.dataEnt != null &&
                                                              ep.idEnc == idEnc && 
                                                              ep.estado.Equals("pendente"))
                                                 .ToList();
            var num_encomendas_hoje = encomendas.Where(ep => ep.Encomenda.dataEnt.Date == DateTime.Now.Date ).ToList().Count;

            if (num_encomendas_hoje == 0)
            {
                Encomenda encomenda = db.Encomendas.Find(idEnc);
                if (encomenda == null)
                {
                    return RedirectToAction("IndexProducao", "Pesquisa");
                }
                encomenda.estado = "confecionada";
                if (ModelState.IsValid)
                {
                    db.Entry(encomenda).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("IndexProducao", "Pesquisa");
        }
















        //// GET: Realizacao
        //public ActionResult IndexProducao()
        //{
        //    var encomendas = db.Encomendas.Include(e => e.Cliente);
        //    return View(encomendas.ToList());
        //}

        // GET: Realizacao/Details/5
        public ActionResult DetailsEncomenda(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        // GET: Realizacao/Create
        public ActionResult CreateEncomenda()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            ViewBag.idCli = new SelectList(db.Clientes, "idCli", "nome");
            return View();
        }

        // POST: Realizacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEncomenda([Bind(Include = "idEnc,idCli,dataEnt,custo,estado,idFunc,rua,numPorta,codPostal,cidade,obs,freguesia,tipoEnc,dataPag,modoPag,fatura")] Encomenda encomenda)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            if (ModelState.IsValid)
            {
                db.Encomendas.Add(encomenda);
                db.SaveChanges();
                return RedirectToAction("IndexEncomenda");
            }

            ViewBag.idCli = new SelectList(db.Clientes, "idCli", "nome", encomenda.idCli);
            return View(encomenda);
        }

        // GET: Realizacao/Edit/5
        public ActionResult EditEncomenda(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCli = new SelectList(db.Clientes, "idCli", "nome", encomenda.idCli);
            return View(encomenda);
        }

        // POST: Realizacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEncomenda([Bind(Include = "idEnc,idCli,dataEnt,custo,estado,idFunc,rua,numPorta,codPostal,cidade,obs,freguesia,tipoEnc,dataPag,modoPag,fatura")] Encomenda encomenda)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            if (ModelState.IsValid)
            {
                db.Entry(encomenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexEncomenda");
            }
            ViewBag.idCli = new SelectList(db.Clientes, "idCli", "nome", encomenda.idCli);
            return View(encomenda);
        }

        // GET: Realizacao/Delete/5
        public ActionResult DeleteEncomenda(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        // POST: Realizacao/Delete/5
        [HttpPost, ActionName("DeleteEncomenda")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedEncomenda(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Autenticacao");
            Encomenda encomenda = db.Encomendas.Find(id);
            db.Encomendas.Remove(encomenda);
            db.SaveChanges();
            return RedirectToAction("IndexEncomenda");
        }
    }
}
