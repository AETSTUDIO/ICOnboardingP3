using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ICOnboardingP3.Models;

namespace ICOnboardingP3.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private readonly OnboardingP3Entities db;

        public ProductsController()
        {
            db = new OnboardingP3Entities();
        }

        // GET api/products
        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }


        //GET api/products/id
        public Product GetProduct(int id)
        {
            var product = db.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return product;
        }

        //POST api/products
        [HttpPost]
        public Product CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            db.Products.Add(product);
            db.SaveChanges();

            return product;
        }

        //PUT /api/products/id
        [HttpPut]
        public void UpdateProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var productInDb = db.Products.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            productInDb.Name = product.Name;
            productInDb.Price = product.Price;

            db.SaveChanges();
        }

        //DELETE /api/products/id
        [HttpDelete]
        public void DeleteProduct(int id)
        {
            var productInDb = db.Products.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Products.Remove(productInDb);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}