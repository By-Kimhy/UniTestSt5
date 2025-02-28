using System.ComponentModel.DataAnnotations;

namespace UniTestSt5.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? Description { get; set; }

    }
}
