using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Interfaces;
using Microsoft.Extensions.Logging;

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

            var articleTag = item.ArticleLink;
            
            var tagIds = articleTag.Select(i => i.TagId).ToList();
            var tags = await _tagRepository.GetTagsByIds(tagIds);
            var names = tags.Select(i => i.Name).ToList();
            var result = new ArticleModel()
            {
                Id = item.ArticleId.ToString(),
                Body = item.Body,
                Date = item.Date,
                Tags = names,
                Title = item.Title
            };
            
            return result;
        }
        
        public void Add(ArticleCreateModel articleModel)
        {
            if (string.IsNullOrEmpty(articleModel.Body) || string.IsNullOrEmpty(articleModel.Title))
            {
                throw new InvalidOperationException("Article title and body cannot be empty");
            }

            if (articleModel.Tags == null)
            {
                throw new InvalidOperationException("Tag cannot be null");
            }
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

        public async Task<TagDetailModel> GetTagDetail(string tagName, string dateString)
        {
            if (!DateTime.TryParseExact(dateString,
                "yyyyMMdd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var date))
            {
                throw new InvalidOperationException("Incorrect datetime format");
            }
            
            var tag = await _tagRepository.GetTagByName(tagName);
            if (tag is null)
                return null;

            var relatedArticleIds = tag.ArticleLink.Select(i => i.ArticleId).ToList();

            var relatedArticles = await _articleRepository.GetRelatedArticlesByDate(relatedArticleIds, date);

            var tagDetailModel = new TagDetailModel();
            tagDetailModel.Tag = tag.Name;
            tagDetailModel.Articles = relatedArticles.Select(i => i.ArticleId.ToString()).Take(10).ToList();
            
            var count = relatedArticles.Count();
            tagDetailModel.Count = count;
            
            var distinctRelatedTag = await GetDistinctRelatedTags(relatedArticles, tag.TagId);

            tagDetailModel.RelatedTags = distinctRelatedTag.Select(i => i.Name).ToList();
            return tagDetailModel;

        }

        private async Task<List<Tag>> GetDistinctRelatedTags(List<Article> relatedArticles, int tagId)
        {
            var allRelatedTagIds = new List<int>();
            
            foreach (var article in relatedArticles)
            {
                var articleTags = article.ArticleLink;
                foreach (var item in articleTags)
                {
                    if (item.TagId != tagId)
                        allRelatedTagIds.Add(item.TagId);
                }
            }

            var distinctRelatedTagIds = allRelatedTagIds.Distinct().ToList();
            return await _tagRepository.GetTagsByIds(distinctRelatedTagIds);
        }
    }
}