using System.ComponentModel.DataAnnotations;

namespace PustokTemplate.Models
{
    public class Feature
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string Icon { get; set; }
    }
}
