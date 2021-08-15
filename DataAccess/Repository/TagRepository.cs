using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(ArticleDbContext repositoryPatternDemoContext) : base(repositoryPatternDemoContext)
        {
        }
        public async Task<List<Tag>> GetTagsByIds(List<int> ids)
        {
            return await (GetAll().Where(i => ids.Contains(i.TagId))).ToListAsync();
        }

        public async Task<Tag> GetTagByName(string name)
        {
            return await GetAll().Include(i => i.ArticleLink).FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}