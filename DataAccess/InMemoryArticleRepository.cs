﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class InMemoryArticleRepository : IArticleRepository
    {
        private static List<Article> _store = new List<Article>()
        {
            new Article() {Id = 1, Body = "Hello World", Date = DateTime.Now, Tags = new List<string>(), Title = "First Article"}
        };
        
        public Article Get(int id)
        {
            return _store.Single(s => s.Id == id);
        }

        public void Add(Article article)
        {
            _store.Add(article);
        }
    }
}