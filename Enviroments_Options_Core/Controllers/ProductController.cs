using Enviroments_Options_Core.Config;
using Enviroments_Options_Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Enviroments_Options_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IOptions<CustomConfig> _options;
        public ProductController(IOptions<CustomConfig> options)
        {
            _options = options;
        }
        [HttpPost]
        public IActionResult GetProduct(Product product)
        {
            product.Name = "Product";
            return Ok(product);
        }
    }
}
