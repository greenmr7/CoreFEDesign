using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repository.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICar _iCar;
        public CarsController(ICar car)
        {
            _iCar = car;
        }

        [HttpGet]
        public async Task<IEnumerable<CarVM>> GetAllCar()
        {
            return await _iCar.getAll();
        }

        [HttpGet("{id}")]
        public CarVM GetIdCar(int id)
        {
            return _iCar.getID(id);
        }

        [HttpPost]
        public IActionResult CreateCar(CarVM carVM)
        {
            var create = _iCar.Create(carVM);
            if (create > 0)
            {
                return Ok(create);
            }
            return BadRequest("Not Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult EditCar(int id, CarVM carVM)
        {
            var edit = _iCar.Update(carVM, id);
            if (edit > 0)
            {
                return Ok(edit);
            }
            return BadRequest("Not Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var delete = _iCar.Delete(id);
            if (delete > 0)
            {
                return Ok(delete);
            }
            return BadRequest("Not Successfully");
        }
    }
}
