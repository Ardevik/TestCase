using InvelliTestCaseWebAPI.Models;
using InvelliTestCaseWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace InvelliTestCaseWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ReadAllProducts()
        {
            ProductRepository productRepository = new ProductRepository();
            List<Product> products = productRepository.GetAllProducts();

            return Ok(products);
        }

        [HttpGet]
        public IHttpActionResult ReadProduct(Guid id)
        {
            ProductRepository productRepository = new ProductRepository();
            Product product = productRepository.GetProduct(id);

            if (product == null)
            {
                return Content(HttpStatusCode.NotFound, "Product Not Found");
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateProduct([FromBody]Product product)
        {
            ProductRepository productRepository = new ProductRepository();
            bool succes = productRepository.AddProduct(product);

            if (succes)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Failed to Create Product");
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateProduct([FromBody]Product product)
        {
            ProductRepository productRepository = new ProductRepository();
            bool succes = productRepository.UpdateProduct(product);

            if (succes)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Failed to Update Product");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(Guid id)
        {
            ProductRepository productRepository = new ProductRepository();
            bool succes = productRepository.DeleteProduct(id);

            if (succes)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Failed to Delete Product");
            }
        }
    }
}
