using InvoiceManager.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.ViewModels
{
    public class EditClientViewModel
    {
        public Client Client { get; set; }
        public string Heading { get; set; }
        public List<AddressViewModel> AddressList { get; set; }

    }
}