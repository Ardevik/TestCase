using InvelliTestCaseMVC.Models;
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
    public class SupplierController : Controller
    {
        
        public async Task<ActionResult> Index()
        {
            List<Supplier> suppliers = new List<Supplier>();

            using(HttpClient client = new HttpClient())
            {
                string uri = "http://localhost/api/supplier/readallsuppliers";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    suppliers = await response.Content.ReadAsAsync<List<Supplier>>();
                }
            }
            return View(suppliers);
        }

        public async Task<ActionResult> Details(Guid? id)
        {
            Supplier supplier = new Supplier();

            using (HttpClient client = new HttpClient())
            {
                string uri = string.Format("http://localhost/api/supplier/readsupplier/{0}", id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    supplier = await response.Content.ReadAsAsync<Supplier>();
                }
            }
            return View(supplier);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Supplier supplier)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = "http://localhost/api/supplier/createsupplier";
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync(uri, supplier);

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

        public async Task<ActionResult> Edit(Guid? id)
        {
            Supplier supplier = new Supplier();

            using (HttpClient client = new HttpClient())
            {
                string uri = string.Format("http://localhost/api/supplier/readsupplier/{0}", id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    supplier = await response.Content.ReadAsAsync<Supplier>();
                }
            }

            return View(supplier);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Supplier supplier)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = "http://localhost/api/supplier/updatesupplier";
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PutAsJsonAsync(uri, supplier);

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


        public async Task<ActionResult> Delete(Guid? id)
        {
            Supplier supplier = new Supplier();

            using (HttpClient client = new HttpClient())
            {
                string uri = string.Format("http://localhost/api/supplier/readsupplier/{0}", id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    supplier = await response.Content.ReadAsAsync<Supplier>();
                }
            }

            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeletePost(Guid? id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = String.Format("http://localhost/api/supplier/deletesupplier/{0}", id);
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
    }
}
