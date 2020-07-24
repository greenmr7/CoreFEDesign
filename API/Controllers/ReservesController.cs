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
    public class ReservesController : ControllerBase
    {
        IReserve _iReserve;
        public ReservesController(IReserve reserve)
        {
            _iReserve = reserve;
        }

        [HttpGet]
        public async Task<IEnumerable<ReserveVM>> GetAllReserve()
        {
            return await _iReserve.getAll();
        }

        [HttpGet("{id}")]
        public ReserveVM GetIdReserve(int id)
        {
            return _iReserve.getID(id);
        }

        [HttpPost]
        public IActionResult CreateReserve(ReserveVM carVM)
        {
            var create = _iReserve.Create(carVM);
            if (create > 0)
            {
                return Ok(create);
            }
            return BadRequest("Not Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult EditReserve(int id, ReserveVM carVM)
        {
            var edit = _iReserve.Update(carVM, id);
            if (edit > 0)
            {
                return Ok(edit);
            }
            return BadRequest("Not Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReserve(int id)
        {
            var delete = _iReserve.Delete(id);
            if (delete > 0)
            {
                return Ok(delete);
            }
            return BadRequest("Not Successfully");
        }
    }
}
