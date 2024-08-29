using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using RapidApiConsume.Models;
using Newtonsoft.Json;
using System.Linq;
namespace RapidApiConsume.Controllers
{
	public class ExchangeController : Controller
	{
		public async Task<IActionResult> Index()
		{
			//List<ExchangeViewModel> exchangeViewModels = new List<ExchangeViewModel>();
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=en-gb&currency=AED"),
				Headers =
	{
		{ "x-rapidapi-key", "cbfb316639msh07f461ef27f15d2p195b36jsnb8c564f14f51" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
				return View(values.exchange_rates.ToList());
			}
			return View();
		}
	}
}
