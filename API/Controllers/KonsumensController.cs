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
    public class KonsumensController : ControllerBase
    {
        IKonsumen _iKonsumen;
        public KonsumensController(IKonsumen konsumen)
        {
            _iKonsumen = konsumen;
        }
        [HttpGet]
        public async Task<IEnumerable<KonsumenVM>> GetAllKonsumen()
        {
            return await _iKonsumen.getAll();
        }

        [HttpGet("{id}")]
        public KonsumenVM GetIdKonsumen(int id)
        {
            return _iKonsumen.getID(id);
        }

        [HttpPost]
        public IActionResult CreateKonsumen(KonsumenVM KonsumenVM)
        {
            var create = _iKonsumen.Create(KonsumenVM);
            if (create > 0)
            {
                return Ok(create);
            }
            return BadRequest("Not Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult EditKonsumen(int id, KonsumenVM KonsumenVM)
        {
            var edit = _iKonsumen.Update(KonsumenVM, id);
            if (edit > 0)
            {
                return Ok(edit);
            }
            return BadRequest("Not Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteKonsumen(int id)
        {
            var delete = _iKonsumen.Delete(id);
            if (delete > 0)
            {
                return Ok(delete);
            }
            return BadRequest("Not Successfully");
        }
    }
}
