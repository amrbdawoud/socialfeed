using System.ComponentModel.DataAnnotations;

namespace socialfeed.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public required string Email { get; set; }
        public string? Bio { get; set; }

        [Required]
        public required string PasswordHash { get; set; }
        public List<Post>? Posts { get; set; }
    }
}