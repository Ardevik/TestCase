using InvelliTestCaseWebAPI.Models;
using InvelliTestCaseWebAPI.Models.ViewModel;
using InvelliTestCaseWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InvelliTestCaseWebAPI.Controllers
{
    public class PurchaseOrderController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ReadAllPurchaseOrders()
        {
            PurchaseOrderRepository purchaseOrderRepository = new PurchaseOrderRepository();
            List<PurchaseOrderViewModel> purchaseOrders = purchaseOrderRepository.GetAllPurchaseOrders();

            return Ok(purchaseOrders);
        }

        [HttpGet]
        public IHttpActionResult ReadPurchaseOrder(Guid id)
        {
            PurchaseOrderRepository purchaseOrderRepository = new PurchaseOrderRepository();
            PurchaseOrderViewModel purchaseOrder = purchaseOrderRepository.GetPurchaseOrder(id);

            if (purchaseOrder == null)
            {
                return Content(HttpStatusCode.NotFound, "PurchaseOrder Not Found");
            }
            else
            {
                return Ok(purchaseOrder);
            }
        }

        [HttpGet]
        public IHttpActionResult ReadPurchaseOrderWith(Guid id)
        {
            PurchaseOrderRepository purchaseOrderRepository = new PurchaseOrderRepository();
            PurchaseOrder purchaseOrder = purchaseOrderRepository.GetPurchaseOrderWith(id);

            if (purchaseOrder == null)
            {
                return Content(HttpStatusCode.NotFound, "PurchaseOrder Not Found");
            }
            else
            {
                return Ok(purchaseOrder);
            }
        }

        [HttpPost]
        public IHttpActionResult CreatePurchaseOrder([FromBody]PurchaseOrder purchaseOrder)
        {
            PurchaseOrderRepository purchaseOrderRepository = new PurchaseOrderRepository();
            bool succes = purchaseOrderRepository.AddPurchaseOrder(purchaseOrder);

            if (succes)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Failed to Create PurchaseOrder");
            }
        }

        [HttpPut]
        public IHttpActionResult UpdatePurchaseOrder([FromBody]PurchaseOrder purchaseOrder)
        {
            PurchaseOrderRepository purchaseOrderRepository = new PurchaseOrderRepository();
            bool succes = purchaseOrderRepository.UpdatePurchaseOrder(purchaseOrder);

            if (succes)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Failed to Update PurchaseOrder");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeletePurchaseOrder(Guid id)
        {
            PurchaseOrderRepository purchaseOrderRepository = new PurchaseOrderRepository();
            bool succes = purchaseOrderRepository.DeletePurchaseOrder(id);

            if (succes)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Failed to Delete PurchaseOrder");
            }
        }
    }
}
