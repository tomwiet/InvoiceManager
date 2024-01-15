using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceManager.Models.Domains
{
    public class Client
    {
        public Client()
        {
            Invoices = new Collection<Invoice>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Nazwa użytkownika jest wymagane")]
        [Display(Name = "Nazwa użytkownika")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Pole Adres")]
        [Display(Name = "Adres")]
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Pole Email jest wymagane")]
        [Display(Name = "Email")]
        public string  Email { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public Address Address { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ApplicationUser User { get; set; }
    }
}