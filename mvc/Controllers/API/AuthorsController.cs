using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services;

namespace mvc.Controllers.API
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        public AuthorService Service;
        public AuthorsController()
        {
            Service = AuthorService.Instance;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var result = Service.GetAuthors();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAuthor(CreateAuthorDTO createAuthor)
        {
            try
            {
                Service.CreateAuthor(createAuthor);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(418, "I am a Teapot");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAuthorById(Guid id)
        {
            return Ok(Service.GetAuthor(id));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(UpdateAuthorDTO updateAuthor)
        {
            Service.UpdateAuthor(updateAuthor);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            Service.DeleteAuthor(id);
            return Ok();
        }
    }
}
