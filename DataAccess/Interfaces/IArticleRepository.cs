using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<Article> GetArticleById (int id);
        Task<List<Article>> GetRelatedArticlesByDate(List<int> id, DateTime date);
        
    }
}