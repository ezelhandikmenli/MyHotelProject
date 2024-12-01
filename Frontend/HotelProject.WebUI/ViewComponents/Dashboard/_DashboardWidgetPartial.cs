﻿using HotelProject.WebUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:50560/api/DashboardWidget/StaffCount");
             var jsonData = await responseMessage.Content.ReadAsStringAsync();
              ViewBag.staffCount = jsonData;

            var client2 =_httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("http://localhost:50560/api/DashboardWidget/BookingCount");
            var jsonData2 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.bookingCount = jsonData2;   


            return View();
        }
    }
}