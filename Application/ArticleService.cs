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
        private readonly IArticleTagRepository _articleTagRepository;

        public ArticleService(IArticleRepository articleRepository,
            ITagRepository tagRepository,
            IArticleTagRepository articleTagRepository)
        {
            _articleRepository = articleRepository;
            _tagRepository = tagRepository;
            _articleTagRepository = articleTagRepository;
        }

        public async Task<ArticleModel> Get(int id)
        {
            var item = await _articleRepository.GetArticleById(id);

            if (item == null)
                return null;

            var articleTag = await _articleTagRepository.GetArticleTagByIds(item.ArticleId);
            
            var tagIds = articleTag.Select(i => i.TagId).ToList();
            var tags = await _tagRepository.GetTagsByIds(tagIds);
            var names = tags.Select(i => i.Name).ToList();
            var result = new ArticleModel()
            {
                Id = item.ArticleId,
                Body = item.Body,
                Date = item.Date,
                Tags = names,
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