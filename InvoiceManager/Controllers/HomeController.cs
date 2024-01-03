using InvoiceManager.Models.Domains;
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
        public ActionResult Index()
        {
            var invoice = new List<Invoice>
            {
                new Invoice
                {
                    Id = 1,
                    Title ="F/1/2024",
                    CreatedDate = DateTime.Now,
                    PaymentDate = DateTime.Now,
                    Value = 999,
                    Client = new Client{Name="Klient 1"}
                },
                new Invoice
                {
                    Id = 2,
                    Title ="F/2/2024",
                    CreatedDate = DateTime.Now,
                    PaymentDate = DateTime.Now,
                    Value = 666,
                    Client = new Client{Name="Klient 2"}
                }
            };
            return View(invoice);
        }
        public ActionResult Invoice(int id=0) 
        {
            return View();
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