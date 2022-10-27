using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using Service.Models;
using Service.Services;
using System.Text.RegularExpressions;

namespace mvc.Controllers
{
    public class NewsController : Controller
    {

        private readonly ILogger<NewsController> _logger;

        public NewsController(ILogger<NewsController> logger)
        {
            _logger = logger;
        }

        public IActionResult StartPage()
        {
            StartPage startPageInfo = new StartPage
            {
                PinnedArticles = ArticleService.Instance.GetPinnedArticles(),
                LatestArticles = ArticleService.Instance.GetLatestArticles(5)
            };

            return View(startPageInfo);
        }

        [HttpGet("[Controller]/{articleUrl}")]
        public IActionResult ArticlePage(string articleUrl)
        {
            var regexId = new Regex(
                "^([0-9A-Fa-f]{8}[-]" +
                "[0-9A-Fa-f]{4}[-]" +
                "[0-9A-Fa-f]{4}[-]" +
                "[0-9A-Fa-f]{4}[-]" +
                "[0-9A-Fa-f]{12})");

            Guid articleId = Guid.Parse(regexId.Match(articleUrl).Value);

            var articlePageInfo = ArticleService.Instance.GetById(articleId);

            return View(articlePageInfo);
        }
        [HttpPost("[Controller]/NewComment")]
        public IActionResult NewComment(ArticleDTO articleDTO)
        {

            var guidId = Guid.Parse(articleDTO.Id.ToString());

            ArticleService.Instance.AddComment(new CreateCommentDTO
            {
                ArticleId = guidId,
                CommentedBy = articleDTO.NewComment.CommentedBy,
                Value = articleDTO.NewComment.Value
            });

            var regexUrl = new Regex(@"[\s+]");
            string articleName = regexUrl.Replace(articleDTO.Title, "-").ToString();
            string url = $"{articleDTO.Id}-{articleName}";

            return RedirectToAction(url);

        }
    }
}