using ArticleBackend.Data;
using ArticleBackend.Interfaces;
using ArticleBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleBackend.Services
{
    public class DbArticleService : IArticleService
    {
        private readonly AppDbContext _context;

        public DbArticleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Article>> GetArticles()
        {
            return await _context.Articles.Include(a => a.Author).ToListAsync();
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await _context.Articles
                .Include(a => a.Author)
                .FirstOrDefaultAsync(a => a.ArticleId == id);
        }

        public async Task<Article> CreateArticle(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }
    }
}
