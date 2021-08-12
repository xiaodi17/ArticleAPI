using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class InMemoryArticleRepository : IArticleRepository
    {
        protected readonly ArticleDbContext DbContext;
        protected readonly DbSet<Article> _dbContext;
        
        public InMemoryArticleRepository(ArticleDbContext dbContext)
        {
            DbContext = dbContext;
            _dbContext = DbContext.Set<Article>();
        }

        public Article Get(int id)
        {
            return _dbContext.SingleOrDefault(s => s.Id == id);
        }

        public void Add(Article article)
        {
            _dbContext.Add(article);
            DbContext.SaveChanges();
        }

        public int GetNextId()
        {
            return _dbContext.Count() + 1;
        }
    }
}