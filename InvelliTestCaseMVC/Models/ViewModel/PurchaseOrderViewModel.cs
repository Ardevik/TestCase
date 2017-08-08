using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvelliTestCaseMVC.Models.ViewModel
{
    public class PurchaseOrderViewModel
    {
        public Guid ID { get; set; }

        public string Code { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Supplier Code")]
        public string SupplierCode { get; set; }

        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        public string Remarks { get; set; }
    }
}