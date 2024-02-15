using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Searchable.Models
{
    public class Tassk
    {
        [Key]
        public string TaskId { get; set; }

        [StringLength(100)]
        public string? Title { get; set; }
        public DateTime DueDate { get; set; }


        [StringLength(75)]
        public string? IsCompleted { get; set; }

        [Required]
        [ForeignKey("Users")]
        [StringLength(50)]
        public string UserId { get; set; }
        public virtual User Users { get; set; }

        [Required]
        [ForeignKey("Categories")]
        [StringLength(50)]
        public string CategoryId { get; set; }
        public virtual User Categories { get; set; }
    }
}