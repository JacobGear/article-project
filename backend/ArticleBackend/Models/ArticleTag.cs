using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleBackend.Models
{
    public class ArticleTag
    {
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
