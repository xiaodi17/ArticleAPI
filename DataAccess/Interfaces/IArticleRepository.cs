using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<Article> GetArticleById (int id);
    }
}