using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvelliTestCaseWebAPI.Models
{
    public class PurchaseOrderDetail
    {
        public Guid ID { get; set; }
        public Guid PurchaseOrderId { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public Decimal UnitPrice { get; set; }
    }
}