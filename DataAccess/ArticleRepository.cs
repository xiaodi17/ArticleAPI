using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ArticleRepository : IArticleRepository
    {
        protected readonly ArticleDbContext DbContext;
        protected readonly DbSet<Article> _dbContextArticle;
        protected readonly DbSet<Tag> _dbContextTag;
        protected readonly DbSet<ArticleTag> _dbContextArticleTag;

        public ArticleRepository(ArticleDbContext dbContext)
        {
            DbContext = dbContext;
            _dbContextArticle = DbContext.Set<Article>();
            _dbContextTag = DbContext.Set<Tag>();
            _dbContextArticleTag = DbContext.Set<ArticleTag>();
        }

        public Article Get(int id)
        {
            var item = _dbContextArticle.SingleOrDefault(s => s.ArticleId == id);
            var tagIds = _dbContextArticleTag.Where(s => s.ArticleId == id).ToList();

            return item;
        }

        public void Add(Article article)
        {
            _dbContextArticle.Add(article);
            DbContext.SaveChanges();
        }
    }
}