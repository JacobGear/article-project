using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticleBackend.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        // Many-to-Many Relationship
        public ICollection<ArticleTag> ArticleTags { get; set; } = new List<ArticleTag>();
    }
}
