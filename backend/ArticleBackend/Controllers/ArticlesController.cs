using ArticleBackend.Interfaces;
using ArticleBackend.Models;
using Microsoft.AspNetCore.Mvc;
namespace ArticleBackend.Controllers
{
   [ApiController]                      // Marks this as an API controller
   [Route("api/articles")]              // Defines the route: /api/articles
   public class ArticlesController : ControllerBase
   {
       private readonly IArticleService _articleService;

       // Inject the ArticleService (DI)
       public ArticlesController(IArticleService articleService)
       {
           _articleService = articleService;
       }

       // GET: api/articles
       [HttpGet]
       public ActionResult<List<Article>> GetAll()
       {
           return Ok(_articleService.GetArticles());
       }
       
       // GET: api/articles/{id}
       [HttpGet("{id}")]
       public ActionResult<Article> GetById(int id)
       {
           var article = _articleService.GetArticleById(id);
           if (article == null) return NotFound();  // 404 if not found
           return Ok(article);
       }

       // Create a New Article
        [HttpPost]
        public async Task<ActionResult<Article>> Create(Article article)
        {
            var createdArticle = await _articleService.CreateArticle(article);
            return CreatedAtAction(nameof(GetById), new { id = createdArticle.ArticleId }, createdArticle);
        }

        // Update an Existing Article
        [HttpPut("{id}")]
        public async Task<ActionResult<Article>> Update(int id, Article article)
        {
            var updatedArticle = await _articleService.UpdateArticle(id, article);
            if (updatedArticle == null) return NotFound();
            return Ok(updatedArticle);
        }

        // Delete an Article
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _articleService.DeleteArticle(id);
            if (!result) return NotFound();
            return NoContent();
        }
   }
}