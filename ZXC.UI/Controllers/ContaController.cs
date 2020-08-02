using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXC.BL;
using ZXC.MODEL.ObjectModel;
using ZXC.UI.Helpers;
using ZXC.UI.Models;

namespace ZXC.UI.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        public ActionResult Index()
        {
            ContaOperations contaOperations = new ContaOperations();
            ClienteOperations clienteOperations = new ClienteOperations();
            VendaOperations vendaOperations = new VendaOperations();

            var tblCliente = clienteOperations.ReadCliente().ToList();
            var tblConta = contaOperations.ReadConta().ToList();
            var tblVenda = vendaOperations.ReadVenda().ToList();

            var tblContaCliente = from cta in tblConta
                                  join cli in tblCliente on cta.Cliente_ID equals cli.ID //into table1
                                  join vnd in tblVenda on cta.Ref equals vnd.Conta//into table1
                                 // from cli in table1.ToList()
                                  select new ViewModelContaCliente
                                  {
                                      conta = cta,
                                      cliente = cli,
                                      venda = vnd
                                  };

            return View(tblContaCliente);
        }

        //GET : EDIT
        public ActionResult Edit(string id)
        {
            ContaOperations contaOperations = new ContaOperations();
            return View(contaOperations.ReadSingleConta(id));
        }

        //POST : EDIT
        [HttpPost]
        public ActionResult Edit(Conta conta)
        {
            ContaOperations contaOperations = new ContaOperations();
            contaOperations.UpdateConta(conta);
            return RedirectToAction("Index");
        }

        //GET : CREATE
        public ActionResult Create()
        {
            return View();
        }

        //POST : CREATE
        [HttpPost]
        public ActionResult Create(Conta conta)
        {
            try
            {
                ContaOperations contaOperations = new ContaOperations();
                contaOperations.CreateConta(conta);
            }
            catch (Exception ex)
            {
                ViewBag.Message = Helper.RemoveSpecialCharacters(ex.Message);
                return View(conta);
            }
           
            return RedirectToAction("Index");
        }
        //TODO : controller vendas

        //GET : DELETE
        [HttpGet]
        public ActionResult Delete(string id)
        {
            ContaOperations contaOperations = new ContaOperations();
            return View(contaOperations.ReadSingleConta(id));
        }

        //POST : DELETE
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(string id)
        {
            ContaOperations contaOperations = new ContaOperations();
            try
            {
                contaOperations.DeleteConta(id);
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
                return View(contaOperations.ReadSingleConta(id));

            }
            return RedirectToAction("Index");
            
        }

    }
}