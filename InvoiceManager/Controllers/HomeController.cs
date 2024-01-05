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
    public class HomeController : Controller
    {
        private InvoiceRepository _invoiceRepository = new InvoiceRepository();
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var invoices = _invoiceRepository.GetInvoices(userId);

            return View(invoices);
        }
        public ActionResult Invoice(int id=0) 
        {
            var userId = User.Identity.GetUserId();
            var invoice = (id==0) ?
                GetNewInvoice(userId) :
                _invoiceRepository.GetInvoice(id,userId);
            var vm = PrepareInvoiceVm(invoice, userId);
            return View(vm);
        }

        private EditInvoiceViewModel PrepareInvoiceVm(Invoice invoice, 
            string userId)
        {
            return new EditInvoiceViewModel
            {
                Invoice = invoice,
                Heading = invoice.Id == 0 ? "Dodawanie nowej faktury": "Faktura",
                Clients = _clientRepository.GetClients(userId),
                MethodOfPayments = _invoiceRepository.GetMethodsOfPayment()


            }
        }

        private Invoice GetNewInvoice(string userId)
        {
            return new Invoice
            {
                UserId = userId,
                CreatedDate = DateTime.Now,
                PaymentDate = DateTime.Now.AddDays(7)

            };
        }

        public ActionResult InvoicePosition(
            int invoiceId,
            int invoicePositionId=0) 
        {
            EditInvoicePositionViewModel vm = null;
            if (invoicePositionId == 0) 
            {
                vm = new EditInvoicePositionViewModel
                {
                    InvoicePosition = new InvoicePosition(),
                    Heading = "Dodawanie nowej pozycji",
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = 1,
                            Name = "Produkt 1"
                        }
                    }
                };
            }
            else
            {
                vm = new EditInvoicePositionViewModel
                {
                    InvoicePosition = new InvoicePosition
                    {
                        Lp=1,Value=123,Quantity=2,ProductId=1
                    },
                    Heading = "Dodawanie nowej pozycji",
                    Products = new List<Product>
                    {
                        new Product {Id = 1,Name = "Produkt 1"}
                    }
                };
            }
            return View(vm); 
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}