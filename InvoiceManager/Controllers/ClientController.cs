using InvoiceManager.Models.Domains;
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
            return View();
        }
        public ActionResult EditClient(int id = 0)
        {
            var userId = User.Identity.GetUserId();
            var client = id == 0 ?
                GetNewClient(userId) :
                _clientRepository.GetClient(id,userId);
            var vm = PrepareClientVm(client);
            
            return View(vm);
        }

        private EditClientViewModel PrepareClientVm(Client client)
        {
            return new EditClientViewModel
            {
                Client = client,
                Heading = client.Id == 0 ?
                "Dodawanie nowego klienta" :
                "Edycja danych klienta",
                AddressList = _addressRepository.GetAdressesVm()

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
        public ActionResult Client(Client client)
        {
            var userId = User.Identity.GetUserId();
            client.UserId = userId;
            if(!ModelState.IsValid)
            {
                var vm = PrepareClientVm(client);
                return View("Invoice", vm);
            }
            if (client.Id == 0)
            {
                var clientId = _clientRepository.Add(client);
                return RedirectToAction("Invoice","Home", new { ClientId = clientId});
            }

            else
            {
                _clientRepository.Update(client);
                var clientId = 0;
                return RedirectToAction("Invoice", "Home", new {ClientId = clientId });

            }
            
            
            
        }
    }
}