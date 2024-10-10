using BlissfulBite.Provider.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlissfulBite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        public readonly ICartProvider _service;

        public CartController(ICartProvider service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult Get() {
            var list = _service.GetCart();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult addCart(int foodId)
        {
            _service.addToCart(foodId);
            return Ok(foodId);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCart(int id) { 
            _service.deleteFood(id);
            return Ok(id);
        }


        [HttpPost("/puchaseAll")]
        public IActionResult purchase()
        {
            _service.purchaseAll();
            string note = "Purchase Completed";
            return Ok(note);
        }
    }
}
