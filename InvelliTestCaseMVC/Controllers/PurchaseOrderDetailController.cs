using InvelliTestCaseMVC.Models;
using InvelliTestCaseMVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InvelliTestCaseMVC.Controllers
{
    public class PurchaseOrderDetailController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<PurchaseOrderDetailViewModel> purchaseOrderDetails = new List<PurchaseOrderDetailViewModel>();

            using (HttpClient client = new HttpClient())
            {
                string uri = "http://localhost/api/purchaseorderdetail/readallpurchaseorderdetails";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    purchaseOrderDetails = await response.Content.ReadAsAsync<List<PurchaseOrderDetailViewModel>>();
                }
            }
            return View(purchaseOrderDetails);
        }

        public async Task<ActionResult> Details(Guid? id)
        {
            PurchaseOrderDetailViewModel purchaseOrderDetail = new PurchaseOrderDetailViewModel();

            using (HttpClient client = new HttpClient())
            {
                string uri = string.Format("http://localhost/api/purchaseorderdetail/readpurchaseorderdetail/{0}", id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    purchaseOrderDetail = await response.Content.ReadAsAsync<PurchaseOrderDetailViewModel>();
                }
            }
            return View(purchaseOrderDetail);
        }

        public async Task<ActionResult> Create()
        {
            await PopulatePurchaseOrder();
            await PopulateProduct();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PurchaseOrderDetail purchaseOrderDetail)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = "http://localhost/api/purchaseorderdetail/createpurchaseorderdetail";
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync(uri, purchaseOrderDetail);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        await PopulatePurchaseOrder(purchaseOrderDetail.PurchaseOrderID);
                        await PopulateProduct(purchaseOrderDetail.ProductID);
                        return View();
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(Guid? id)
        {
            PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();

            using (HttpClient client = new HttpClient())
            {
                string uri = string.Format("http://localhost/api/purchaseorderdetail/readpurchaseorderdetailwith/{0}", id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    purchaseOrderDetail = await response.Content.ReadAsAsync<PurchaseOrderDetail>();
                }
            }
            await PopulatePurchaseOrder(purchaseOrderDetail.PurchaseOrderID);
            await PopulateProduct(purchaseOrderDetail.ProductID);
            return View(purchaseOrderDetail);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(PurchaseOrderDetail purchaseOrderDetail)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = "http://localhost/api/purchaseorderdetail/updatepurchaseorderdetail";
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PutAsJsonAsync(uri, purchaseOrderDetail);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        await PopulatePurchaseOrder(purchaseOrderDetail.PurchaseOrderID);
                        await PopulateProduct(purchaseOrderDetail.ProductID);
                        return View();
                    }
                }
            }
            catch
            {
                return View();
            }
        }


        public async Task<ActionResult> Delete(Guid? id)
        {
            PurchaseOrderDetailViewModel purchaseOrderDetail = new PurchaseOrderDetailViewModel();

            using (HttpClient client = new HttpClient())
            {
                string uri = string.Format("http://localhost/api/purchaseorderdetail/readpurchaseorderdetail/{0}", id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    purchaseOrderDetail = await response.Content.ReadAsAsync<PurchaseOrderDetailViewModel>();
                }
            }
            return View(purchaseOrderDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeletePost(Guid? id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = String.Format("http://localhost/api/purchaseorderdetail/deletepurchaseorderdetail/{0}", id);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        private async Task PopulatePurchaseOrder(object selectedValue = null)
        {
            List<PurchaseOrder> purchaseOrders = new List<PurchaseOrder>();

            using (HttpClient client = new HttpClient())
            {
                string uri = "http://localhost/api/purchaseorder/readallpurchaseorders";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    purchaseOrders = await response.Content.ReadAsAsync<List<PurchaseOrder>>();
                    ViewBag.PurchaseOrderID = new SelectList(purchaseOrders, "ID", "Code", selectedValue);
                }
            }
        }

        private async Task PopulateProduct(object selectedValue = null)
        {
            List<Product> products = new List<Product>();

            using (HttpClient client = new HttpClient())
            {
                string uri = "http://localhost/api/product/readallproducts";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    products = await response.Content.ReadAsAsync<List<Product>>();
                    ViewBag.ProductID = new SelectList(products, "ID", "Name", selectedValue);
                }
            }
        }
    }
}