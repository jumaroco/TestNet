using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestNet.Data;
using TestNet.Models;

namespace TestNet.Controllers
{
    //[Authorize]
    public class ClientController : Controller
    {
        [Authorize]
        // GET: Client
        public ActionResult Index()
        {
            try
            {
                using(testmvcEntities db =new testmvcEntities())
                {
                    List<ClientViewModel> lstClients = new List<ClientViewModel>();
                    lstClients = (from q in db.client
                           select new ClientViewModel
                           {
                               id = q.id,
                               first_name = q.first_name,
                               second_name=q.second_name,
                               surname = q.surname,
                               second_surname=q.second_surname,
                               dpi=q.dpi
                           }).ToList();
                    return View(lstClients);
                }

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [Authorize]
        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            ClientViewModel cliente;
            using (testmvcEntities db = new testmvcEntities())
            {
                var cl = new client();
                cliente = new ClientViewModel();
                cl = db.client.Find(id);
                cliente.id = cl.id;
                cliente.first_name = cl.first_name;
                cliente.second_name = cl.second_name;
                cliente.surname = cl.surname;
                cliente.second_surname = cl.second_surname;
                cliente.dpi = cl.dpi;

            }
            return View(cliente);
        }
        [Authorize]
        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(ClientViewModel client)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    using (testmvcEntities db = new testmvcEntities())
                    {
                        var cl = new client();
                        cl.first_name = client.first_name;
                        cl.second_name = client.second_name;
                        cl.surname = client.surname;
                        cl.second_surname = client.second_surname;
                        cl.dpi = client.dpi;
                        db.client.Add(cl);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            ClientViewModel cliente;
            using (testmvcEntities db = new testmvcEntities())
            {
                var cl = new client();
                cliente = new ClientViewModel();
                cl = db.client.Find(id);
                cliente.id = cl.id;
                cliente.first_name = cl.first_name;
                cliente.second_name = cl.second_name;
                cliente.surname = cl.surname;
                cliente.second_surname = cl.second_surname;

            }
            return View(cliente);
        }
        [Authorize]
        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(ClientViewModel client)
        {
            try
            {
                // TODO: Add update logic here
                using (testmvcEntities db = new testmvcEntities())
                {
                    var cl = new client();
                    cl = db.client.Find(client.id);
                    cl.first_name = client.first_name;
                    cl.second_name = client.second_name;
                    cl.surname = client.surname;
                    cl.second_surname = client.second_surname;
                    cl.dpi = client.dpi;
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            ClientViewModel cliente;
            using (testmvcEntities db = new testmvcEntities())
            {
                var cl = new client();
                cliente = new ClientViewModel();
                cl = db.client.Find(id);
                cliente.id = cl.id;
                cliente.first_name = cl.first_name;
                cliente.second_name = cl.second_name;
                cliente.surname = cl.surname;
                cliente.second_surname = cl.second_surname;
                cliente.dpi = cl.dpi;
            }
            return View(cliente);
        }
        [Authorize]
        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(ClientViewModel client)
        {
            try
            {
                // TODO: Add delete logic here
                using (testmvcEntities db = new testmvcEntities())
                {
                    var cl = new client();
                    cl = db.client.Find(client.id);
                    db.client.Remove(cl);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Report()
        {
            using (testmvcEntities db = new testmvcEntities())
            {
                List<ClientViewModel> lstClients = new List<ClientViewModel>();
                lstClients = (from q in db.client
                              select new ClientViewModel
                              {
                                  id = q.id,
                                  first_name = q.first_name,
                                  second_name = q.second_name,
                                  surname = q.surname,
                                  second_surname = q.second_surname,
                                  dpi = q.dpi
                              }).ToList();
                return View(lstClients);
            }
                
        }
        [Authorize]
        public ActionResult Pdf()
        {
            return new ActionAsPdf("Report") { 
             FileName="Clientes.pdf"
            };
        }
    }
}
