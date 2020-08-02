using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXC.BL;
using ZXC.MODEL.ObjectModel;
using ZXC.UI.Helpers;

namespace ZXC.UI.Controllers
{
    public class ClienteController : Controller
    {
        
        // GET: Index
        public ActionResult Index()
        {
            ClienteOperations clienteOperations = new ClienteOperations();
            return View(clienteOperations.ReadCliente());
        }

        //GET: Edit
        public ActionResult Edit(int id)
        {
            ClienteOperations clienteOperations = new ClienteOperations();
            var cliente = clienteOperations.ReadSingleCliente(id);
            return View(cliente);
        }

        //POST: Edit
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            ClienteOperations clienteOperations = new ClienteOperations();
            //cliente.Data = System.DateTime.UtcNow;
            clienteOperations.UpdateCliente(cliente);
            return RedirectToAction("Index");
        }

        //GET: Create
        public ActionResult Create()
        {
            return View(new Cliente());
        }

        //POST: Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            ClienteOperations clienteOperations = new ClienteOperations();
            clienteOperations.CreateCliente(cliente);
            return RedirectToAction("Index");
        }

        //GET: Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ClienteOperations clienteOperations = new ClienteOperations();
            var cliente = clienteOperations.ReadSingleCliente(id);
            return View(cliente);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            ClienteOperations clienteOperations = new ClienteOperations();
            
            try
            {
                clienteOperations.DeleteCliente(id);
            }
            catch (Exception ex)
            {
                
                ViewBag.Message = Helper.RemoveSpecialCharacters(ex.Message);
                return View(clienteOperations.ReadSingleCliente(id));

            }
          
            return RedirectToAction("Index");

            

        }

    }
}