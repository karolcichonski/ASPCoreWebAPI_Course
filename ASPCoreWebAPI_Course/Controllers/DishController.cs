using ASPCoreWebAPI_Course.Models;
using ASPCoreWebAPI_Course.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWebAPI_Course.Controllers
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController]
    public class DishController:ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpPost]
        public ActionResult Post([FromRoute]int restaurantId, [FromBody]CreateDishDto dto)
        {
            var newDishId = _dishService.Create(restaurantId, dto);
            return Created($"api/{restaurantId}/dish/{newDishId}", null);
        }


        [HttpGet("{dishId}")]
        public ActionResult Get([FromRoute] int restaurantId, [FromRoute] int DishId)
        {
            DishDto dish = _dishService.GetById(restaurantId, DishId);

            return Ok(dish);
        }

        [HttpGet]
        public ActionResult Get([FromRoute] int restaurantId)
        {
            var result = _dishService.GetAll(restaurantId);

            return Ok(result);
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute]int restaurantId)
        {
            _dishService.RemoveAll(restaurantId);

            return NoContent();
        }

    }
}
