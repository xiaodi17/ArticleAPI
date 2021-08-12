using System.Collections;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ITagRepository
    {
        Tag Get(int id);
        void Add(Tag tag);
        void Add(ICollection<Tag> tags);
    }
}