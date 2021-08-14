using System;
using System.Collections.Generic;
using System.Linq;
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

        public ArticleModel Get(int id)
        {
            var item = _articleRepository.Get(id);
            var articleTag = item.ArticleLink;
            var tagIds = articleTag.Select(i => i.TagId).ToList();
            var tags = _tagRepository.Get(tagIds).Select(i => i.Name).ToList();
            var result = new ArticleModel()
            {
                Id = item.ArticleId,
                Body = item.Body,
                Date = item.Date,
                Tags = tags,
                Title = item.Title
            };
            
            return result;
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