using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application;
using Newtonsoft.Json;

namespace ArticleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleAPIController : ControllerBase
    {
        private readonly ILogger<ArticleAPIController> _logger;
        private readonly ArticleService _articleService;

        public ArticleAPIController(ILogger<ArticleAPIController> logger, ArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        [HttpGet("/articles/{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            var item = await _articleService.Get(id);
            if (item == null)
            {
                return BadRequest("Article not found");
            }
            
            return Ok(item);
        }

        [HttpGet("/tags/{tagName}/{date}")]
        public async Task<ActionResult> GetTag([FromRoute] string tagName, [FromRoute] string date)
        {
            var item = await _articleService.GetTagDetail(tagName, date);

            if (item == null)
            {
                return BadRequest("Tag not found");
            }

            return Ok(item);

        }
        
        [HttpPost("/articles")]
        public ActionResult CreateArticle([FromQuery] ArticleCreateModel article)
        {
            _articleService.Add(article);
            return Ok();
        }
    }
}
