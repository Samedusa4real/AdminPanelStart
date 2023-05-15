using System.ComponentModel.DataAnnotations;

namespace PustokTemplate.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
