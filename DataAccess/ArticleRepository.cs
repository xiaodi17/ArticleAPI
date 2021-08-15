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

        public async Task Add(Article article)
        {
            await AddAsync(article);
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await GetAll().Include(i=>i.ArticleLink).FirstOrDefaultAsync(x => x.ArticleId == id);
        }

        public async Task<List<Article>> GetRelatedArticlesByDate(List<int> ids, DateTime date)
        {
            return await GetAll().Where(i => ids.Contains(i.ArticleId) && i.Date.Date == date.Date).ToListAsync();
        }
    }
}