using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ArticleModel> Get(int id)
        {
            var item = await _articleRepository.GetArticleById(id);

            if (item == null)
                return null;
            
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
        
        public void Add(ArticleCreateModel articleModel)
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
            _articleRepository.AddAsync(article);
        }
    }
}