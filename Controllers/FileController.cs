using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Anbar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        FileExtensionContentTypeProvider fileExtensionContentTypeProvider;
        public FileController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            this.fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }
        [HttpGet]
        public ActionResult GetFile()
        {
            string pathtofile = Download.ToDownload.mypath;
            var bytes = System.IO.File.ReadAllBytes(pathtofile);
            if(!fileExtensionContentTypeProvider.TryGetContentType(pathtofile, out var contentType))
            {
                contentType = "Application/octet-stream";
            }
            return File(bytes,contentType, Path.GetFileName(pathtofile));
        }
    }
}
