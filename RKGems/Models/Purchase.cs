using Microsoft.AspNetCore.Mvc;
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
        [Remote("IsItemNumberExist", "Purchases", AdditionalFields = "ItemNumber",
                ErrorMessage = "Item Number already exists")]
        public string ItemNumber { get; set; }

        [Required]
        [Range(0,10000000000000000000)]
        [Display(Name = "Quantity")]
        public double PurchaseWeight { get; set; }

        [Required]
        [Range(0, 10000000000000000000)]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Display(Name = "Party Name")]
        public string PartyName { get; set; }

        [Required]
        [Display(Name = "Due Date")]
        [CustomValidation(typeof(Purchase), "ValidateDueDate")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; } = DateTime.Now;

        public static ValidationResult ValidateDueDate(DateTime dueDate)
        {
            if (dueDate.Date < DateTime.Today)
            {
                return new ValidationResult("Due Date cannot be in the past.");
            }
            return ValidationResult.Success;
        }
    }
}
