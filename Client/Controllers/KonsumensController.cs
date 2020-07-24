using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class KonsumensController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44339/api/")
        };
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult LoadKonsumen()
        {
            IEnumerable<Konsumen> konsumens = null;
            var resTask = client.GetAsync("konsumens");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Konsumen>>();
                readTask.Wait();
                konsumens = readTask.Result;
            }
            else
            {
                konsumens = Enumerable.Empty<Konsumen>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(konsumens);

        }

        public JsonResult GetById(int Id)
        {
            Konsumen konsumens = null;
            var resTask = client.GetAsync("konsumens/" + Id);
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                konsumens = JsonConvert.DeserializeObject<Konsumen>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            return Json(konsumens);
        }

        public JsonResult InsertOrUpdate(Konsumen konsumens, int id_konsumen)
        {
            try
            {
                var json = JsonConvert.SerializeObject(konsumens);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                if (konsumens.id_konsumen == 0)
                {
                    var result = client.PostAsync("konsumens", byteContent).Result;
                    return Json(result);
                }
                else if (konsumens.id_konsumen == id_konsumen)
                {
                    var result = client.PutAsync("konsumens/" + id_konsumen, byteContent).Result;
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
            var result = client.DeleteAsync("konsumens/" + id).Result;
            return Json(result);
        }
    }
}
