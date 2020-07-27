using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repository;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        ChartRepo _chartRepo;
        public ChartController(ChartRepo chartRepo)
        {
            _chartRepo = chartRepo;
        }

        [HttpGet]
        [Route("Pie")]
        public async Task<IEnumerable<PieChartVM>> GetPie()
        {
            return await _chartRepo.getPie();
        }

        [HttpGet]
        [Route("Line")]
        public async Task<IEnumerable<LineChartVM>> GetLine()
        {
            return await _chartRepo.getLine();
        }
    }
}
