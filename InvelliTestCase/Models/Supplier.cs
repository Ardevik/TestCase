using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvelliTestCaseWebAPI.Models
{
    public class Supplier
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}