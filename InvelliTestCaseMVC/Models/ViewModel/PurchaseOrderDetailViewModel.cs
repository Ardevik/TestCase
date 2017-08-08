using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvelliTestCaseMVC.Models.ViewModel
{
    public class PurchaseOrderDetailViewModel
    {
        public Guid ID { get; set; }

        [Display(Name = "Purchase Order Code")]
        public string PurchaseOrderCode { get; set; }

        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Unit Price")]
        public Decimal UnitPrice { get; set; }
    }
}