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

        public Task<Article> UpdateArticle(int id, Article article)
        {
            var existingArticle = _articles.FirstOrDefault(a => a.ArticleId == id);
            if (existingArticle == null)
            {
                return Task.FromResult<Article>(null);
            }

            existingArticle.Title = article.Title;
            existingArticle.Content = article.Content;
            existingArticle.AuthorId = article.AuthorId;
            existingArticle.CategoryId = article.CategoryId;

            return Task.FromResult(existingArticle);
        }

        public Task<bool> DeleteArticle(int id)
        {
            var article = _articles.FirstOrDefault(a => a.ArticleId == id);
            if (article == null)
            {
                return Task.FromResult(false);
            }

            _articles.Remove(article);
            return Task.FromResult(true);
        }
    }
}
