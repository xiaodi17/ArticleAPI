﻿using System;
using DataAccess;

namespace Application
{
    public class ArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public Article Get(int id)
        {
            return _articleRepository.Get(id);
        }
        
        public Article Add(ArticleCreateModel articleModel)
        {
            var article = new Article
            {
                Body = articleModel.Body,
                Date = DateTime.Now,
                Title = articleModel.Title
            };

            _articleRepository.Add(article);
            return article;
        }
    }
}