using System.ComponentModel.DataAnnotations;

namespace PustokTemplate.Models
{
    public class Setting
    {
        [Required]
        [MaxLength(25)]
        public string Key { get; set; }
        [Required]
        [MaxLength(250)]
        public string Value { get; set; }
    }
}
