using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RKGems.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Item Number")]
        public string ItemNumber { get; set; }

        [Required]
        [Range(0,10000000000000000000)]
        [Display(Name = "Quantity")]
        public double PurchaseWeight { get; set; }

        [Required]
        [Range(0, 10000000000000000000)]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Party Name")]
        public string PartyName { get; set; }

        [Required]
        [Display(Name = "Due Date")]
        [CustomValidation(typeof(Purchase), "ValidateDeliveryDate")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; } = DateTime.Now;

        public static ValidationResult ValidateDeliveryDate(DateTime deliveryDateToValidate)
        {
            if (deliveryDateToValidate.Date < DateTime.Today)
            {
                return new ValidationResult("Delivery Date cannot be in the past.");
            }
            return ValidationResult.Success;
        }
    }
}
