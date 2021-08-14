using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class InMemoryTagRepository : ITagRepository
    {
        protected readonly ArticleDbContext DbContext;
        protected readonly DbSet<Tag> _dbContextTag;

        public InMemoryTagRepository(ArticleDbContext dbContext)
        {
            DbContext = dbContext;
            _dbContextTag = DbContext.Set<Tag>();
        }

        public Tag Get(int id)
        {
            return _dbContextTag.SingleOrDefault(s => s.TagId == id);
        }

        public List<Tag> Get(List<int> ids)
        {
            return _dbContextTag.Where(t => ids.Contains(t.TagId)).ToList();
        }

        public void Add(Tag tag)
        {
            _dbContextTag.Add(tag);
            DbContext.SaveChanges();
        }

        public void Add(ICollection<Tag> tags)
        {
            _dbContextTag.AddRange(tags);
            DbContext.SaveChanges();
        }
    }
}