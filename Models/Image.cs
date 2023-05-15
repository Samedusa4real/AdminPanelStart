using System.ComponentModel.DataAnnotations;

namespace PustokTemplate.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Url { get; set; }
        [Required]
        public bool? IsMain { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
