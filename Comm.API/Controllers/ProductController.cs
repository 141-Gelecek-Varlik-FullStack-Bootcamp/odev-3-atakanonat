using Comm.Model;
using Comm.Service.Product;
using Microsoft.AspNetCore.Mvc;

namespace Comm.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpPost]
        public Common<Model.Product.Product> AddProduct([FromBody] Model.Product.Product newProduct)
        {
            var result = productService.Add(newProduct);
            return result;
        }
    }
}