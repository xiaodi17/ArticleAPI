using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class InMemoryArticleRepository : IArticleRepository
    {
        protected readonly ArticleDbContext DbContext;
        protected readonly DbSet<Article> _dbContextArticle;

        public InMemoryArticleRepository(ArticleDbContext dbContext)
        {
            DbContext = dbContext;
            _dbContextArticle = DbContext.Set<Article>();
        }

        public Article Get(int id)
        {
            var item = _dbContextArticle.SingleOrDefault(s => s.ArticleId == id);
            return item;
        }

        public void Add(Article article)
        {
            _dbContextArticle.Add(article);
            DbContext.SaveChanges();
        }
    }
}