using System;

namespace DataAccess
{
    public interface IArticleRepository
    {
        Article Get(int id);
        void Add(Article article);
        int GetNextId();
    }
}