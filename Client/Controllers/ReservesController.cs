using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class ReservesController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44339/api/")
        };
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult LoadReserve()
        {
            IEnumerable<ReserveVM> reserveVM = null;
            var resTask = client.GetAsync("reserves");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<ReserveVM>>();
                readTask.Wait();
                reserveVM = readTask.Result;
            }
            else
            {
                reserveVM = Enumerable.Empty<ReserveVM>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(reserveVM);

        }

        public JsonResult GetById(int Id)
        {
            ReserveVM reserveVM = null;
            var resTask = client.GetAsync("reserves/" + Id);
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                reserveVM = JsonConvert.DeserializeObject<ReserveVM>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            return Json(reserveVM);
        }

        public JsonResult InsertOrUpdate(ReserveVM reserveVM, int id_reserve)
        {
            try
            {
                var json = JsonConvert.SerializeObject(reserveVM);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                if (reserveVM.id_reserve == 0)
                {
                    var result = client.PostAsync("reserves", byteContent).Result;
                    return Json(result);
                }
                else if (reserveVM.id_reserve == id_reserve)
                {
                    var result = client.PutAsync("reserves/" + id_reserve, byteContent).Result;
                    return Json(result);
                }

                return Json(404);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult Delete(int id)
        {
            var result = client.DeleteAsync("reserves/" + id).Result;
            return Json(result);
        }
    }
}
