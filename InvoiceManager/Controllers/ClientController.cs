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
        public ActionResult AddEditClient(int id = 0)
        {
            var userId = User.Identity.GetUserId();
            var client = id == 0 ?
                GetNewClient(userId) :
                _clientRepository.GetClient(id,userId);
            var vm = PrepareClientVm(client);
            
            return View(vm);
        }

        private AddEditClientViewModel PrepareClientVm(Client client)
        {
            return new AddEditClientViewModel
            {
                Client = client,
                Address = client.Address,
                Heading = client.Id == 0 ?
                "Dodawanie nowego klienta" :
                "Edycja danych klienta",
                Addresses = _addressRepository.GetAdresses()
              

            };
        }

        private Client GetNewClient(string userId)
        {
            return new Client
            {
                UserId = userId,
            };
        }
    }
}