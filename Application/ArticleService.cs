using System;
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
        
        public void Add(Article articleModel)
        {
            var article = new Article
            {
                Body = articleModel.Body,
                Date = DateTime.Now,
                Tags = articleModel.Tags,
                Title = articleModel.Title
            };

            article.Id = _articleRepository.GetNextId();
            
            _articleRepository.Add(article);
        }
    }
}