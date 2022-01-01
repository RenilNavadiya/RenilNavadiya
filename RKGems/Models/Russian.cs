using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RKGems.Models
{
    public class Russian
    {
        [Key]
        public int RussianId { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public double RussianQuantity { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public double RussianWeight { get; set; }

        public int PurchaseId { get; set; }

        [Display(Name = "Item Number")]
        public Purchase PurchaseItemNumber { get; set; }

        public int IdOfFourP { get; set; }

        [ForeignKey("IdOfFourP")]
        public FourP WeightOfFourP { get; set; }
    }
}
