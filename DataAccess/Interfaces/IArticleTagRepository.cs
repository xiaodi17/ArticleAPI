using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IArticleTagRepository : IRepository<ArticleTag>
    {
        Task<List<ArticleTag>> GetArticleTagByIds(int id);
    }
}