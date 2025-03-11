using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticleBackend.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        // Relationships
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
