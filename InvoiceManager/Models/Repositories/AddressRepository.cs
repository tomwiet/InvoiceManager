using InvoiceManager.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceManager.Models.Repositories
{
    public class AddressRepository
    {
        public List<Address> GetAdresses()
        {
                using (var context = new ApplicationDbContext())
                {
                    return context.Addresses.ToList();
                }
            
        }


        
    }
}