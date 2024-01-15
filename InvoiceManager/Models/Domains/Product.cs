using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceManager.Models.Domains
{
    public class Product
    {
        public Product()
        {
            InvoicePositions = new Collection<InvoicePosition>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pole Wartość jest wymagane")]
        [Display(Name="Wartość")]
        public decimal Value { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public string UserId {  get; set; }

        public ICollection<InvoicePosition> InvoicePositions { get; set; }
        public ApplicationUser User { get; set; }
    }
}