using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminFileController : Controller
    {
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Index(IFormFile file)
        //{
        //    var stream = new MemoryStream();
        //    await file.CopyToAsync(stream);
        //    var bytes = stream.ToArray();

        //    ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
        //    byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
        //    MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
        //    multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
        //    var httpclient = new HttpClient();
        //    await httpclient.PostAsync("http://localhost:50560/api/FileProcess", multipartFormDataContent);
        //    return View();
        //}
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    var bytes = stream.ToArray();

                    using (var byteArrayContent = new ByteArrayContent(bytes))
                    {
                        byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                        using (var multipartFormDataContent = new MultipartFormDataContent())
                        {
                            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
                            using (var httpClient = new HttpClient())
                            {
                                await httpClient.PostAsync("http://localhost:50560/api/FileProcess", multipartFormDataContent);
                            }
                        }
                    }
                }
            }
            return View();
        } 
    }
}
