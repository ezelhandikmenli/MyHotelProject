using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        //Consume işlemi apiyi tüketme
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:50560/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        //public async Task<IActionResult> ApprovedReservation2(int id)
        //{
            
        //    var client = _httpClientFactory.CreateClient();
            
            
        //    var responseMessage = await client.GetAsync($"http://localhost:50560/api/Booking/BokingAproved?id={id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {

        //        return RedirectToAction("Index");
        //    }
        //    return View();

        //}
        public async Task<IActionResult> ApprovedReservation(int id)
        {

            var client = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync($"http://localhost:50560/api/Booking/BokingAproved?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> CancelReservation(int id)
        {

            var client = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync($"http://localhost:50560/api/Booking/BokingCancel?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> WaitReservation(int id)
        {

            var client = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync($"http://localhost:50560/api/Booking/BokingWait?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }



    }
}
