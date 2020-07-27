using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Client.Models;
using System.Net.Http;
using API.ViewModels;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44339/api/")
        };
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult LoadPieChart()
        {
            IEnumerable<PieChartVM> pieCharts = null;
            var resTask = client.GetAsync("chart/pie");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<PieChartVM>>();
                readTask.Wait();
                pieCharts = readTask.Result;
            }
            else
            {
                pieCharts = Enumerable.Empty<PieChartVM>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(pieCharts);
        }

        public JsonResult LoadLineChart()
        {
            IEnumerable<LineChartVM> lineCharts = null;
            var resTask = client.GetAsync("chart/line");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<LineChartVM>>();
                readTask.Wait();
                lineCharts = readTask.Result;
            }
            else
            {
                lineCharts = Enumerable.Empty<LineChartVM>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(lineCharts);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
