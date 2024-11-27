using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AppUserListWithWorkLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AppUserListWithWorkLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> UserLisst()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:50560/api/AppUserWorkLocation");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserWithWorkLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
