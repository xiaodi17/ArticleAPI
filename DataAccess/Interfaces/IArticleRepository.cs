namespace DataAccess.Interfaces
{
    public interface IArticleRepository
    {
        Article Get(int id);
        void Add(Article article);
    }
}