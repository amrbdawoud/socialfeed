using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace socialfeed.Models
{
    public class Follows
    {
        [Required]
        [Key]
        [ForeignKey(nameof(Follower))]
        public required int FollowerId { get; set; }

        [Required]
        [ForeignKey(nameof(Following))]
        public required int FollowingId { get; set; }

        [Required]
        public required DateTime TimeStamp { get; set; }

        [Required]
        public required User Follower { get; set; }

        [Required]
        public required User Following { get; set; }
    }
}
