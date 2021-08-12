﻿using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Get([FromRoute] int id)
        {
            var item = _articleService.Get(id);
            if (item == null)
            {
                return BadRequest("Article not found");
            }
            return Ok(item);
        }
        
        [HttpPost("/articles")]
        public ActionResult CreateArticle([FromQuery] ArticleCreateModel article)
        {
            var item = _articleService.Add(article);
            return Created("default", item);
        }
    }
}