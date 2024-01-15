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
    public class ProductController : Controller
    {
        private ProductRepository _productRepository = new ProductRepository();
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            
            var products = _productRepository.GetProducts(userId);
            
            return View(products);
           
        }
        public ActionResult Product(int id = 0) 
        {
            var userId = User.Identity.GetUserId();
            
            var product = id==0 ? GetNewProduct():
                _productRepository.GetProduct(id,userId);
            
            var vm = PrepareProductVm(product);
            return View(vm);
        }

        public EditProductViewModel PrepareProductVm(Product product)
        {
            return new EditProductViewModel
            {
                
                Product = product,
                Heading = product.Id == 0 ? "Dodawanie nowego produktu" : "Produkt",
            };
        }

        public Product GetNewProduct()
        {
            var userId = User.Identity.GetUserId();
            return new Product() 
            { 
                UserId = userId
            };
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Product(Product product) 
        {
            var userId = User.Identity.GetUserId();
            product.UserId = userId;

            if (product.Id == 0)
                _productRepository.Add(product);
            else
                _productRepository.Update(product);

            return RedirectToAction("Index", "Product");

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                _productRepository.Delete(id, userId);

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