using InvoiceManager.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.ViewModels
{
    public class AddressViewModel
    {
        public AddressViewModel(Address address)
        {
            Address = address;
            ConcatAddressesRow = $"{address.PostalCode} {address.City} , {address.Street} {address.Number}";
        }
        public Address Address { get; set; }
        public string ConcatAddressesRow { get; set; }
    }
}