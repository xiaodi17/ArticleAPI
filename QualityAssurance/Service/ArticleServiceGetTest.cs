using Application;
using DataAccess;
using Xunit;

namespace QualityAssurance.Service
{
    public class ArticleServiceGetTest
    {
        private IArticleRepository _repository = new InMemoryArticleRepository();
        
        [Fact]
        public void Service_Get_Test()
        {
            var service = new ArticleService(_repository);
            var item = service.Get(1);
            Assert.Equal(1, item.Id);
        }
        
        [Fact]
        public void Service_Get_Invalid_Test()
        {
            var service = new ArticleService(_repository);
            var item = service.Get(2);
            Assert.Null(item);
        }
    }
}