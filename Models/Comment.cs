using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace socialfeed.Models
{
    public class Comment
    {
        [Required]
        [Key]
        public required int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Post))]
        public required int PostId { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public required int UserId { get; set; }

        [Required]
        [StringLength(2000)]
        public required string Content { get; set; }

        [Required]
        public required DateTime TimeStamp { get; set; }

        [Required]
        public required Post Post { get; set; }
        
        [Required]
        public required User User { get; set; }
    }
}
