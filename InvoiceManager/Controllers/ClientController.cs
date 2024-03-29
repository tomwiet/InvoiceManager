﻿using InvoiceManager.Models.Domains;
using InvoiceManager.Models.Repositories;
using InvoiceManager.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceManager.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private ClientRepository _clientRepository = new ClientRepository();
        private AddressRepository _addressRepository = new AddressRepository();
        
        // GET: Client
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var client = _clientRepository.GetClients(userId);

            return View(client);
        }
        public ActionResult Client(int id = 0,int fromInvoice = 0)
        {
            var userId = User.Identity.GetUserId();
            var client = id == 0 ?
                GetNewClient(userId) :
                _clientRepository.GetClient(id,userId);
            var vm = PrepareClientVm(client,fromInvoice);
            
            return View(vm);
        }

        private EditClientViewModel PrepareClientVm(Client client,int fromInvoice = 0)
        {
            return new EditClientViewModel
            {
                Client = client,
                Heading = client.Id == 0 ?
                "Dodawanie nowego klienta" :
                "Edycja danych klienta",
                AddressList = _addressRepository.GetAdressesVm(),
                FromInvoice = fromInvoice
            };
        }

        private Client GetNewClient(string userId)
        {
            return new Client
            {
                UserId = userId,
            };
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Client(Client client,int fromInvoice = 0)
        {
            var userId = User.Identity.GetUserId();
            client.UserId = userId;
            if(!ModelState.IsValid)
            {
                var vm = PrepareClientVm(client,fromInvoice);
                return View("Invoice", vm);
            }
            if (client.Id == 0)
                _clientRepository.Add(client);
            else
                _clientRepository.Update(client);
            
            if(fromInvoice == 0)
                 return RedirectToAction("Index","Client");

            return RedirectToAction("Invoice", "Home", new { clientId = client.Id });
        }
       


        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                _clientRepository.Delete(id, userId);

            }
            catch (Exception exeption)
            {
                //logowanie błędu do pliku
                return Json(new { Success = false, Message = exeption.Message });
            }

            return Json(new { Success = true });
        }
    }
}