namespace ArticleBackend.Interfaces
{
    public interface IArticleService
    {
        List<Article> GetArticles();
        Article GetArticleById(int id);
    }
}
