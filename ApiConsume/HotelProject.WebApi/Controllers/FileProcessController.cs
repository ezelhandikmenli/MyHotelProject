using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessController : ControllerBase
    {
        //[HttpPost]
        //public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        //{
        //    var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        //    var path = Path.Combine(Directory.GetCurrentDirectory(), "files/" + fileName);
        //    var stream = new FileStream(path, FileMode.Create);
        //    await file.CopyToAsync(stream);
        //    return Created("", file);
        //}
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Dosya boş.");
            }

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "files", fileName);

            // 'using' bloğu ile akışı otomatik olarak kapatıyoruz
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Created("", file);
        }
    }
}
