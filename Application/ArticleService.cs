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
                Title = articleModel.Title
            };

            var tags = new List<Tag>();
            foreach (var item in articleModel.Tags)
            {
                var tag = new Tag {Name = item};
                tags.Add(tag);
            }

            var tagLink = new List<ArticleTag>();

            foreach (var tag in tags)
            {
                var result = new ArticleTag
                {
                    Tag = tag,
                    Article = article
                };
                tagLink.Add(result);
            }

            article.TagsLink = tagLink;
            _articleRepository.Add(article);
            // _tagRepository.Add(tags);
            
            return article;
        }
    }
}