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
    public class MerksController : ControllerBase
    {
        IMerk _iMerk;
        public MerksController(IMerk iMerk)
        {
            _iMerk = iMerk;
        }

        [HttpGet]
        public async Task<IEnumerable<MerkVM>> GetAllMerk()
        {
            return await _iMerk.getAll();
        }

        [HttpGet("{id}")]
        public MerkVM GetIdMerk(int id)
        {
            return _iMerk.getID(id);
        }

        [HttpPost]
        public IActionResult CreateMerk(MerkVM merkVM)
        {
            var create = _iMerk.Create(merkVM);
            if (create > 0)
            {
                return Ok(create);
            }
            return BadRequest("Not Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult EditMerk(int id, MerkVM merkVM)
        {
            var edit = _iMerk.Update(merkVM, id);
            if (edit > 0)
            {
                return Ok(edit);
            }
            return BadRequest("Not Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMerk(int id)
        {
            var delete = _iMerk.Delete(id);
            if (delete > 0)
            {
                return Ok(delete);
            }
            return BadRequest("Not Successfully");
        }
    }
}
