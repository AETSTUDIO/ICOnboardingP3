using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ICOnboardingP3.Models;

namespace ICOnboardingP3.Controllers.Api
{
    public class SalesRecordsController : ApiController
    {
        private readonly OnboardingP3Entities db;

        public SalesRecordsController()
        {
            db = new OnboardingP3Entities();
        }

        //GET api/salesrecords
        public IEnumerable<ProductSold> GetSalesRecords()
        {
            var productSolds = db.ProductSolds;

            return productSolds;
        }

        //GET api/salesrecords/id
        public ProductSold GetSalesRecord(int id)
        {
            var productSold = db.ProductSolds.SingleOrDefault(ps => ps.Id == id);

            if (productSold == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return productSold;
        }

        //POST api/salesrecords
        [HttpPost]
        public ProductSold CreateSalesRecord(ProductSold productSold)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            db.ProductSolds.Add(productSold);
            db.SaveChanges();

            return productSold;
        }

        //PUT /api/salesrecords/id
        [HttpPut]
        public void UpdateSalesRecord(int id, ProductSold productSold)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var productSoldInDb = db.ProductSolds.SingleOrDefault(ps => ps.Id == id);

            if (productSoldInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            productSoldInDb.DateSold = productSold.DateSold;
            productSoldInDb.CustomerId = productSold.CustomerId;
            productSoldInDb.ProductId = productSold.ProductId;
            productSoldInDb.StoreId = productSold.StoreId;

            db.SaveChanges();
        }

        //DELETE /api/salesrecords/id
        [HttpDelete]
        public void DeleteSalesRecord(int id)
        {
            var productSoldInDb = db.ProductSolds.SingleOrDefault(ps => ps.Id == id);

            if (productSoldInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.ProductSolds.Remove(productSoldInDb);
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