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
    public class ProductController : Controller
    {
        public async Task<ActionResult> Index()
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
                }
            }
            return View(products);
        }

        public async Task<ActionResult> Details(Guid? id)
        {
            Product product = new Product();

            using (HttpClient client = new HttpClient())
            {
                string uri = string.Format("http://localhost/api/product/readproduct/{0}", id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    product = await response.Content.ReadAsAsync<Product>();
                }
            }
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = "http://localhost/api/product/createproduct";
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync(uri, product);

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
            Product product = new Product();

            using (HttpClient client = new HttpClient())
            {
                string uri = string.Format("http://localhost/api/product/readproduct/{0}", id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    product = await response.Content.ReadAsAsync<Product>();
                }
            }
            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Product product)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = "http://localhost/api/product/updateproduct";
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PutAsJsonAsync(uri, product);

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
            Product product = new Product();

            using (HttpClient client = new HttpClient())
            {
                string uri = string.Format("http://localhost/api/product/readproduct/{0}", id);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    product = await response.Content.ReadAsAsync<Product>();
                }
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeletePost(Guid? id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = String.Format("http://localhost/api/product/deleteproduct/{0}", id);
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