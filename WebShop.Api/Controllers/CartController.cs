using Microsoft.AspNetCore.Mvc;
using WebShop.Core.DTO;
using WebShop.Core.Interfaces.Service;

namespace WebShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // GET: api/cart
        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {
            var cartItems = await _cartService.GetCartItemsAsync();
            return Ok(cartItems);
        }

        // POST: api/cart
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto addToCartDto)
        {
            await _cartService.AddToCartAsync(addToCartDto.ProductID, addToCartDto.Quantity);
            return NoContent();
        }

        // PUT: api/cart
        [HttpPut]
        public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartItemDto updateCartItemDto)
        {
            await _cartService.UpdateCartItemAsync(updateCartItemDto.ProductID, updateCartItemDto.Quantity);
            return NoContent();
        }

        // DELETE: api/cart/{productId}
        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            await _cartService.RemoveFromCartAsync(productId);
            return NoContent();
        }

        // GET: api/cart/summary
        [HttpGet("summary")]
        public async Task<IActionResult> GetCartSummary()
        {
            var summary = await _cartService.GetCartTotalAsync();
            return Ok(summary);
        }
    }
}
