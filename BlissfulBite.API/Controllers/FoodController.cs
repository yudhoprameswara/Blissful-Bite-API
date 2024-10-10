using BlissfulBite.Provider.Interface;
using BlissfulBite.ViewModel.Food;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlissfulBite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodProvider _service;

        public FoodController(IFoodProvider service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var model = _service.getAllFoods();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetFood(int id)
        {
            var model = _service.getFood(id);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateOrEditFood([FromBody] FoodVM foodVm)
        {
            if (foodVm == null)
            {
                return BadRequest(new { message = "Invalid food data" });
            }

            if (foodVm.id > 0)
            {

                var existingFood = _service.getFood(foodVm.id);
                if (existingFood == null)
                {
                    return NotFound(new { message = "Food not found" });
                }

                _service.EditFood(foodVm);
                return Ok(new { message = "Food updated successfully" });
            }
            else
            {
                _service.CreateFood(foodVm);
                return Ok(new { message = "Food created successfully" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) { 
            _service.DeleteFood(id);
            return Ok(new { message = "Food wiht Id = "+id + " deleted"});
        }
    }
}
