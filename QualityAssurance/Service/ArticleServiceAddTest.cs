using System.Collections.Generic;
using Application;
using DataAccess;
using Xunit;

namespace QualityAssurance.Service
{
    public class ArticleServiceAddTest
    {
        private IArticleRepository _repository = new InMemoryArticleRepository();
        
        [Fact]
        public void Service_Add_Test()
        {
            var service = new ArticleService(_repository);
            var article = new ArticleCreateModel()
            {
                Title = "First",
                Body = "Body",
                Tags = new List<string>()
            };
            
            service.Add(article);

            var item = service.Get(2);
            Assert.Equal(2, item.Id);
        }
    }
}