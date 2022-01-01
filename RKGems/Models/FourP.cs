using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RKGems.Models
{
    public class FourP
    {
        [Key]
        public int FourPId { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public double FourPQuantity { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public double FourPWeight { get; set; }

        public int PurchaseId { get; set; }

        [Display(Name = "Item Number")]
        public Purchase PurchaseItemNumber { get; set; }

        public int IdOfResult { get; set; }

        [ForeignKey("IdOfResult")]
        public Result WeightOfResult { get; set; }
    }
}
