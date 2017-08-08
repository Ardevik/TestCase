using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvelliTestCaseWebAPI.Models.ViewModel
{
    public class PurchaseOrderViewModel
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string Remarks { get; set; }
    }
}