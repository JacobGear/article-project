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

         public async Task<Article> UpdateArticle(int id, Article article)
        {
            var existingArticle = await _context.Articles.FindAsync(id);
            if (existingArticle == null)
            {
                return null;
            }

            // Dynamically update properties (only if they are changed)
            _context.Entry(existingArticle).CurrentValues.SetValues(article);
            await _context.SaveChangesAsync();

            return existingArticle;
        }

        public async Task<bool> DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return false;
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
