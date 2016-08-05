﻿using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData;

namespace APMWebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:53608", "*", "*")]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [EnableQuery()]
        public IHttpActionResult Get()
        {
            var productRepository = new ProductRepository();
            return Ok(productRepository.Retrieve().AsQueryable());
        }

        // GET: api/Products/5
        public IHttpActionResult Get(int id)
        {
            Product product;
            var productRepository = new ProductRepository();

            if (id > 0)
            {
                var products = productRepository.Retrieve();
                product = products.FirstOrDefault(p => p.ProductId == id);
                Console.Out.WriteLine("hello");
                if (product == null)
                {
                    Console.Out.WriteLine(product);
                    return NotFound();
                }
            }
            else
            {
                product = productRepository.Create();
            }
            return Ok(product);
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }
            var productRepository = new ProductRepository();
            var newProduct = productRepository.Save(product);
            if (newProduct == null)
            {
                return Conflict();
            }
            return Created<Product>(Request.RequestUri + newProduct.ProductId.ToString(),
                newProduct);
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }
            var productRepository = new ProductRepository();
            var updatedProduct = productRepository.Save(id, product);
            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok();

        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
