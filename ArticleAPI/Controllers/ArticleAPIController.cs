using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using DataAccess;

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
        public Article Get([FromRoute] int id)
        {
            return _articleService.Get(id);
        }
    }
}
