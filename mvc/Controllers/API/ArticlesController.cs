using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services;

namespace mvc.Controllers.API
{
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        public ArticleService Service;
        public ArticlesController()
        {
            Service = ArticleService.Instance;
        }

        [HttpGet]
        public IActionResult GetAllArticles()
        {
            var result = Service.GetAllArticles();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateArticle(CreateArticleDTO createArticle)
        {
            Service.CreateArticle(createArticle);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetArticleById(Guid id)
        {
            return Ok(Service.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateArticle(UpdateArticleDTO updateArticle)
        {
            Service.UpdateArticle(updateArticle);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(Guid id)
        {
            try
            {
                Service.DeleteArticle(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(418, "I am a Proper Teapot");
            }
        }
    }
}
