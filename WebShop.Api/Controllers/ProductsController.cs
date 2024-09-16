﻿using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Interfaces.Service;
using WebShop.Core.DTO;

namespace WebShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProducts(int pageNumber = 1, int pageSize = 10)
         {
            IEnumerable<ProductDto> products = await _productService.GetProductsAsync(pageNumber, pageSize);
            return Ok(products);
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            ProductDto product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("{productId}/check-stock")]
        public async Task<IActionResult> CheckStock(int productId, [FromQuery] int quantity)
        {
            // Llamada al servicio para verificar el stock
            bool isAvailable = await _productService.CheckProductStockAsync(productId, quantity);

            if (isAvailable)
            {
                return Ok(new { isAvailable = true });
            }
            else
            {
                return Ok(new { isAvailable = false });
            }
        }
    }
}
