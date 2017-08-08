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
    public class PurchaseOrderController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<PurchaseOrderViewModel> purchaseOrders = new List<PurchaseOrderViewModel>();

            using (HttpClient client = new HttpClient())
            {
                string uri = "http://localhost/api/purchaseorder/readallpurchaseorders";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    purchaseOrders = await response.Content.ReadAsAsync<List<PurchaseOrderViewModel>>();
                }
            }
            return View(purchaseOrders);
        }

        public async Task<ActionResult> Details(Guid? id)
        {
            PurchaseOrderViewModel purchaseOrder = new PurchaseOrderViewModel();

            using (HttpClient client = new HttpClient())
            {
                string uri = string.Format("http://localhost/api/purchaseorder/readpurchaseorder/{0}", id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    purchaseOrder = await response.Content.ReadAsAsync<PurchaseOrderViewModel>();
                }
            }
            return View(purchaseOrder);
        }

        public async Task<ActionResult> Create()
        {
            await PopulateSupplier();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PurchaseOrder purchaseOrder)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = "http://localhost/api/purchaseorder/createpurchaseorder";
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync(uri, purchaseOrder);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        await PopulateSupplier(purchaseOrder.SupplierID);
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
            PurchaseOrder purchaseOrder = new PurchaseOrder();

            using (HttpClient client = new HttpClient())
            {
                string uri = string.Format("http://localhost/api/purchaseorder/readpurchaseorderwith/{0}", id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    purchaseOrder = await response.Content.ReadAsAsync<PurchaseOrder>();
                }
            }
            await PopulateSupplier(purchaseOrder.SupplierID);
            return View(purchaseOrder);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(PurchaseOrder purchaseOrder)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = "http://localhost/api/purchaseorder/updatepurchaseorder";
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PutAsJsonAsync(uri, purchaseOrder);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        await PopulateSupplier(purchaseOrder.SupplierID);
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
            PurchaseOrderViewModel purchaseOrder = new PurchaseOrderViewModel();

            using (HttpClient client = new HttpClient())
            {
                string uri = string.Format("http://localhost/api/purchaseorder/readpurchaseorder/{0}", id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    purchaseOrder = await response.Content.ReadAsAsync<PurchaseOrderViewModel>();
                }
            }
            return View(purchaseOrder);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeletePost(Guid? id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = String.Format("http://localhost/api/purchaseorder/deletepurchaseorder/{0}", id);
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

        private async Task PopulateSupplier(object selectedValue = null)
        {
            List<Supplier> suppliers = new List<Supplier>();

            using (HttpClient client = new HttpClient())
            {
                string uri = "http://localhost/api/supplier/readallsuppliers";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    suppliers = await response.Content.ReadAsAsync<List<Supplier>>();
                    ViewBag.SupplierID = new SelectList(suppliers, "ID", "Name", selectedValue);
                }
            }
        }
    }
}