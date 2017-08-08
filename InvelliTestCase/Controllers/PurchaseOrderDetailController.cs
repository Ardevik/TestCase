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
    public class PurchaseOrderDetailController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ReadAllPurchaseOrderDetails()
        {
            PurchaseOrderDetailRepository purchaseOrderDetailRepository = new PurchaseOrderDetailRepository();
            List<PurchaseOrderDetailViewModel> purchaseOrderDetails = purchaseOrderDetailRepository.GetAllPurchaseOrderDetails();

            return Ok(purchaseOrderDetails);
        }

        [HttpGet]
        public IHttpActionResult ReadPurchaseOrderDetail(Guid id)
        {
            PurchaseOrderDetailRepository purchaseOrderDetailRepository = new PurchaseOrderDetailRepository();
            PurchaseOrderDetailViewModel purchaseOrderDetails = purchaseOrderDetailRepository.GetPurchaseOrderDetail(id);

            if (purchaseOrderDetails == null)
            {
                return Content(HttpStatusCode.NotFound, "PurchaseOrderDetail Not Found");
            }
            else
            {
                return Ok(purchaseOrderDetails);
            }
        }

        [HttpGet]
        public IHttpActionResult ReadPurchaseOrderDetailWith(Guid id)
        {
            PurchaseOrderDetailRepository purchaseOrderDetailRepository = new PurchaseOrderDetailRepository();
            PurchaseOrderDetail purchaseOrderDetails = purchaseOrderDetailRepository.GetPurchaseOrderDetailWith(id);

            if (purchaseOrderDetails == null)
            {
                return Content(HttpStatusCode.NotFound, "PurchaseOrderDetail Not Found");
            }
            else
            {
                return Ok(purchaseOrderDetails);
            }
        }

        [HttpPost]
        public IHttpActionResult CreatePurchaseOrderDetail([FromBody]PurchaseOrderDetail purchaseOrderDetail)
        {
            PurchaseOrderDetailRepository purchaseOrderDetailRepository = new PurchaseOrderDetailRepository();
            bool succes = purchaseOrderDetailRepository.AddPurchaseOrderDetail(purchaseOrderDetail);

            if (succes)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Failed to Create PurchaseOrderDetail");
            }
        }

        [HttpPut]
        public IHttpActionResult UpdatePurchaseOrderDetail([FromBody]PurchaseOrderDetail purchaseOrderDetail)
        {
            PurchaseOrderDetailRepository purchaseOrderDetailRepository = new PurchaseOrderDetailRepository();
            bool succes = purchaseOrderDetailRepository.UpdatePurchaseOrderDetail(purchaseOrderDetail);

            if (succes)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Failed to Update PurchaseOrderDetail");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeletePurchaseOrderDetail(Guid id)
        {
            PurchaseOrderDetailRepository purchaseOrderDetailRepository = new PurchaseOrderDetailRepository();
            bool succes = purchaseOrderDetailRepository.DeletePurchaseOrderDetail(id);

            if (succes)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Failed to Delete PurchaseOrderDetail");
            }
        }
    }
}
