using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApp.DataAccess;
using NetCoreApp.Entities;

namespace NetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductDal _productDal;
        public ProductsController(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IActionResult Get()
        {

            var product = _productDal.GetList();
            return Ok(product);
        }
        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            try
            {
                var product = _productDal.Get(x => x.ProductId == productId);
                if (product == null)
                {
                    return NotFound("Ürün Bulunamadı");
                }
                return Ok(product);
            }
            catch (Exception)
            {
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Post([FromForm]Product product)
        {
            try
            {
                _productDal.Add(product);
                return new StatusCodeResult(201);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Put([FromForm]Product product)
        {
            try
            {
                _productDal.Update(product);
                return Ok(product);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{ProductId}")]
        public IActionResult Delete(int ProductId)
        {
            try
            {
                _productDal.Delete(new Product { ProductId = ProductId });
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("GetProductsWithDetails")]
        public IActionResult GetProductsWithDetails()
        {
            try
            {
                var result = _productDal.GetProductWithDetails();
                return Ok(result);
            }
            catch (Exception)
            {

            }
            return BadRequest();
        }

    }
}