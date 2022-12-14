using CatalogService.Business.Abstract;
using CatalogService.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("gethomeall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetHomeProducts();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ProductDTO productDTO)
        {
            var addData = _productService.AddProduct(productDTO);
            if (!addData.Success)
            {
                return BadRequest(addData.Message);
            }
            return Ok(addData.Message);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(string id,ProductDTO productDTO)
        {
            var addData = await _productService.UpdateProduct(id,productDTO);
            if (!addData.Success)
            {
                return BadRequest(addData.Message);
            }
            return Ok(addData.Message);
        }

        [HttpGet("getbyid/{productId}")]
        public IActionResult GetById(string productId)
        {
            var result = _productService.GetProductById(productId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
