using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(ArticleDbContext repositoryPatternDemoContext) : base(repositoryPatternDemoContext)
        {
        }

        public void Add(Article article)
        {
            AddAsync(article);
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.ArticleId == id);
        }
    }
}