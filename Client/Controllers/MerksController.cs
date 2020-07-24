using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Models;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class MerksController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44339/api/")
        };
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult LoadMerk()
        {
            IEnumerable<Merk> merks = null;
            var resTask = client.GetAsync("merks");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Merk>>();
                readTask.Wait();
                merks = readTask.Result;
            }
            else
            {
                merks = Enumerable.Empty<Merk>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(merks);

        }

        public JsonResult GetById(int Id)
        {
            Merk merks = null;
            var resTask = client.GetAsync("merks/" + Id);
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                merks = JsonConvert.DeserializeObject<Merk>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            return Json(merks);
        }

        public JsonResult InsertOrUpdate(Merk merks, int id_merk)
        {
            try
            {
                var json = JsonConvert.SerializeObject(merks);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                if (merks.id_merk == 0)
                {
                    var result = client.PostAsync("merks", byteContent).Result;
                    return Json(result);
                }
                else if (merks.id_merk == id_merk)
                {
                    var result = client.PutAsync("merks/" + id_merk, byteContent).Result;
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
            var result = client.DeleteAsync("merks/" + id).Result;
            return Json(result);
        }
    }
}
