using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvelliTestCaseMVC.Models
{
    public class PurchaseOrder
    {
        public Guid ID { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        public Guid SupplierID { get; set; }

        public string Remarks { get; set; }
    }
}