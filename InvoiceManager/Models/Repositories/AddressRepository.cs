using InvoiceManager.Models.Domains;
using InvoiceManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace InvoiceManager.Models.Repositories
{
    public class AddressRepository
    {
        public List<Address> GetAddresses()
        {
                using (var context = new ApplicationDbContext())
                {
                    return context.Addresses.ToList();
                }
        }

        public List<AddressViewModel> GetAdressesVm() 
        {
            var addresses = GetAddresses();
            List<AddressViewModel> addresRow = new List<AddressViewModel>();
            
            foreach(var address in addresses)
            {
                addresRow.Add(new AddressViewModel(address));
                    
            }

            return addresRow;
        }

        


        
    }
}