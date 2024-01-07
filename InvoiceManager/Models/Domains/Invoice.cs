using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.Domains
{
    public class Invoice
    {
        public Invoice()
        {
            InvoicePositions = new Collection<InvoicePosition>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage ="Pole Nr faktury jest wymagane")]
        [Display(Name ="Nr faktury")]
        public string Title { get; set; }

        [Display(Name = "Wartość")]
        [Required(ErrorMessage = "Pole Wartość jest wymagane")]
        public decimal Value { get; set; }

        [Display(Name = "Metoda płatności")]
        [Required(ErrorMessage = "Pole Metoda płatności jest wymagane")]
        public int MethodOfPaymentId { get; set; }

        [Display(Name = "Termin zapłaty")]
        [Required(ErrorMessage = "Pole Termin zapłaty jest wymagane")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Data utworzenia")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Uwagi")]
        public string Comments { get; set; }

        [Display(Name ="Nazwa klienta")]
        [Required(ErrorMessage = "Pole Nazwa klienta jest wymagane")]
        public int ClientId { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        
        public MethodOfPayment MethodOfPayment { get; set; }
        public Client Client { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<InvoicePosition> InvoicePositions { get; set; }
        

    }
}