using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApiDemo.Dtos;
using WebApiDemo.Entities;
using WebApiDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            var result = _productService.GetProductsWithDetails()
                .Select(p =>
                {
                    return new ProductDto
                    {
                        ProductId = p.ProductId,
                        CategoryName = p.Category.CategoryName,
                        ProductName = p.ProductName,
                        UnitPrice = p.UnitPrice
                    };
                });
            return result;

        }

        [HttpGet("ByName{name}")]
        public IEnumerable<ProductDto> Get(string name)
        {
            var result = _productService.GetProductsWithDetails()
                .Where(x => x.ProductName.Contains(name))
                .Select(p =>
                {
                    return new ProductDto
                    {
                        ProductId = p.ProductId,
                        CategoryName = p.Category.CategoryName,
                        ProductName = p.ProductName,
                        UnitPrice = p.UnitPrice
                    };
                });
            return result;

        }



        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductDto Get(int id)
        {
            var p = _productService.Get(id);

            return new ProductDto
            {
                ProductId = p.ProductId,
                CategoryName = p.Category.CategoryName,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice
            };

        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
