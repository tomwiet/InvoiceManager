﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace InvoiceManager.Models.Domains
{
    public class MethodOfPayment
    {
        public MethodOfPayment()
        {
            Invoices = new Collection<Invoice>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}