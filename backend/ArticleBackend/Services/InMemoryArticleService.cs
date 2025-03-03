using ArticleBackend.Interfaces;

public class InMemoryArticleService : IArticleService
{
    private readonly List<Article> _articles = new()
    {
        new Article { Id = 1, Title = "First Article", Content = "This is the first article." },
        new Article { Id = 2, Title = "Second Article", Content = "This is the second article." }
    };

    public List<Article> GetArticles() => _articles;
    public Article GetArticleById(int id) => _articles.FirstOrDefault(a => a.Id == id);
}
