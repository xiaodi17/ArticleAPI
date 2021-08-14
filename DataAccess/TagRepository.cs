using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(ArticleDbContext repositoryPatternDemoContext) : base(repositoryPatternDemoContext)
        {
        }
        public async Task<List<Tag>> GetTagsByIds(List<int> ids)
        {
            //return await GetAll().Where(i => ids.Contains(i.TagId)).ToListAsync();
            var x = GetAll().Where(i => ids.Contains(i.TagId));
            var y = x.ToListAsync();
            return await y;
        }
    }
}