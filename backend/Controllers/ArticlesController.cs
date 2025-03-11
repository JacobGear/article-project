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
   }
}