using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleBackend.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public int? ArticleId { get; set; }  // Nullable: Can be for articles or comments
        public Article Article { get; set; }

        public int? CommentId { get; set; }  // Nullable: Can be for articles or comments
        public Comment Comment { get; set; }
    }
}
