using ArticleBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleBackend.Interfaces
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticles();
        Task<Article> GetArticleById(int id);
        Task<Article> CreateArticle(Article article);
        Task<Article> UpdateArticle(int id, Article article);
        Task<bool> DeleteArticle(int id);
    }
}
