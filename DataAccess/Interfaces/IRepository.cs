using System.Linq;
using System.Threading.Tasks;

public interface IRepository<TEntity> where TEntity : class, new()
{
    Task<TEntity> AddAsync(TEntity entity);
}