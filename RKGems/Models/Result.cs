using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RKGems.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public double ResultThan { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public double ResultWeight { get; set; }

        public int PurchaseId { get; set; }

        [Display(Name = "Item Number")]
        public Purchase PurchaseItemNumber { get; set; }
    }
}
