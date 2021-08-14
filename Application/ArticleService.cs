using System;
using System.Collections.Generic;
using DataAccess;
using DataAccess.Interfaces;

namespace Application
{
    public class ArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ITagRepository _tagRepository;

        public ArticleService(IArticleRepository articleRepository, ITagRepository tagRepository)
        {
            _articleRepository = articleRepository;
            _tagRepository = tagRepository;
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
                Title = articleModel.Title,
                ArticleLink = new List<ArticleTag>()
            };

            var tags = new List<Tag>();

            var articletags = new List<ArticleTag>();
            
            foreach (var item in articleModel.Tags)
            {
                var tag = new Tag {Name = item};
                tags.Add(tag);

                var articletag = new ArticleTag();
                articletag.Article = article;
                articletag.Tag = tag;
                
                articletags.Add(articletag);
            }
            
            article.ArticleLink.AddRange(articletags);
            _articleRepository.Add(article);
            // _tagRepository.Add(tags);
            
            return article;
        }
    }
}