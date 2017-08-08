using InvelliTestCaseWebAPI.Models;
using InvelliTestCaseWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InvelliTestCaseWebAPI.Controllers
{
    public class SupplierController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ReadAllSuppliers()
        {
            SupplierRepository supplierRepository = new SupplierRepository();
            List<Supplier> suppliers = supplierRepository.GetAllSuppliers();

            return Ok(suppliers);
        }

        [HttpGet]
        public IHttpActionResult ReadSupplier(Guid id)
        {
            SupplierRepository supplierRepository = new SupplierRepository();
            Supplier supplier = supplierRepository.GetSupplier(id);

            if (supplier == null)
            {
                return Content(HttpStatusCode.NotFound, "Supplier Not Found");
            }
            else
            {
                return Ok(supplier);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateSupplier([FromBody]Supplier supplier)
        {
            SupplierRepository supplierRepository = new SupplierRepository();
            bool succes = supplierRepository.AddSupplier(supplier);

            if (succes)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Failed to Create Supplier");
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateSupplier([FromBody]Supplier supplier)
        {
            SupplierRepository supplierRepository = new SupplierRepository();
            bool succes = supplierRepository.UpdateSupplier(supplier);

            if (succes)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Failed to Update Supplier");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteSupplier(Guid id)
        {
            SupplierRepository supplierRepository = new SupplierRepository();
            bool succes = supplierRepository.DeleteSupplier(id);

            if (succes)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Failed to Delete Supplier");
            }
        }
    }
}
