using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ArticleTagRepository : Repository<ArticleTag>, IArticleTagRepository
    {
        public ArticleTagRepository(ArticleDbContext repositoryPatternDemoContext) : base(repositoryPatternDemoContext)
        {
        }

        public Task<List<ArticleTag>> GetRelationshipByArticleId(int id)
        {
            return GetAll().Where(i => i.ArticleId == id).ToListAsync();
        }
        
    }
}