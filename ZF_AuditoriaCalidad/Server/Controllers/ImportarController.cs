using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ZF_AuditoriaCalidad.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportarController : ControllerBase
    {
        private readonly IHostEnvironment _environment;

        public ImportarController(IHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<IActionResult> Post([FromForm]IFormFile File)
        {
            if(File == null || File.Length == 0)
            {
                return BadRequest("File Empty or Null");
            }

            string newFileName = File.FileName;
            string extension = Path.GetExtension(newFileName);

            string[] allowedExtensions = new string[] { ".xlsx" };

            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest("File not valid");
            }

            string fileName = $"{Guid.NewGuid()}{extension}";
            string filePath = Path.Combine(_environment.ContentRootPath, "UploadedFile", newFileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await File.CopyToAsync(fileStream);
            }

            return Ok($"UploadedFile/{newFileName}");
        }
    }
}
