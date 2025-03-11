using ArticleBackend.Models; // ✅ Add this at the top
using ArticleBackend.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ArticleBackend.Services
{
    public class InMemoryArticleService : IArticleService
    {
        private readonly List<Article> _articles = new()
        {
            new Article { ArticleId = 1, Title = "First Article", Content = "This is the first article.", AuthorId = 1, CategoryId = 1 },
            new Article { ArticleId = 2, Title = "Second Article", Content = "This is the second article.", AuthorId = 2, CategoryId = 2 }
        };

        public Task<List<Article>> GetArticles() => Task.FromResult(_articles);

        public Task<Article> GetArticleById(int id) =>
            Task.FromResult(_articles.FirstOrDefault(a => a.ArticleId == id));

        public Task<Article> CreateArticle(Article article)
        {
            article.ArticleId = _articles.Count + 1;
            _articles.Add(article);
            return Task.FromResult(article);
        }
    }
}
