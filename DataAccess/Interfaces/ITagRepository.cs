using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<List<Tag>> GetTagsByIds(List<int> id);
        Task<Tag> GetTagByName(string name);
    }
}