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
    public class VendaController : Controller
    {
        // GET: Venda
        public ActionResult Index()
        {
            VendaOperations vendaOperations = new VendaOperations();
            return View(vendaOperations.ReadVenda());
        }

        //GET: Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            VendaOperations vendaOperations = new VendaOperations();
            return View(vendaOperations.ReadVendaSingle(id));
        }

        //POST: EDIT
        [HttpPost]
        public ActionResult Edit(Venda venda)
        {
            VendaOperations vendaOperations = new VendaOperations();
            try
            {
                vendaOperations.UpdateVenda(venda);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
                return View(vendaOperations.ReadVendaSingle(venda.ID));
            }
            
        }

        //GET: Create
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        //POST: Create
        [HttpPost]
        public ActionResult Create(Venda venda)
        {
            try
            {
                VendaOperations vendaOperations = new VendaOperations();
                vendaOperations.CreateVenda(venda);
            }

            catch (Exception ex)
            {
                ViewBag.Message = Helper.RemoveSpecialCharacters(ex.Message);
                return View(venda);
            }

            return RedirectToAction("Index");
        }

        //GET: Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            VendaOperations vendaOperations = new VendaOperations();
            return View(vendaOperations.ReadVendaSingle(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost (int id)
        {
            //TODO: DELETEPOST

            return View();
        }

    }
}