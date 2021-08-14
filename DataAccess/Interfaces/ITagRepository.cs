using System.Collections;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ITagRepository
    {
        Tag Get(int id);
        List<Tag> Get(List<int> id);
        void Add(Tag tag);
        void Add(ICollection<Tag> tags);
    }
}