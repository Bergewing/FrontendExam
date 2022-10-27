using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace mvc.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public ImageService Service;

        public ImagesController()
        {
            Service = ImageService.Instance;
        }
        [HttpPost]
        public IActionResult UploadImage()
        {
            Service.Upload(Request.Form.Files[0]);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetImage()
        {
            return Ok(Service.GetAll());
        }
    }
}
