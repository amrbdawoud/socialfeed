using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace socialfeed.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public required int UserId { get; set; }

        [Required]
        [StringLength(2000)]
        public required string Content { get; set; }

        [Required]
        public required DateTime TimeStamp { get; set; }
        
        [Required]
        public required User User { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
