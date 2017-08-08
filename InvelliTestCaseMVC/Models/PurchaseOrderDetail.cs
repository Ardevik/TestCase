using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvelliTestCaseMVC.Models
{
    public class PurchaseOrderDetail
    {
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Purchase Order Code")]
        public Guid PurchaseOrderID { get; set; }

        [Required]
        [Display(Name = "Product")]
        public Guid ProductID { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Unit Price")]
        public Decimal UnitPrice { get; set; }
    }
}