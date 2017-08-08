using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvelliTestCaseWebAPI.Models.ViewModel
{
    public class PurchaseOrderDetailViewModel
    {
        public Guid ID { get; set; }
        public string PurchaseOrderCode{ get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Decimal UnitPrice { get; set; }
    }
}