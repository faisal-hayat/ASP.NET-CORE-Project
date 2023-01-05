using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExampleProject.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage ="Display Order must be b/w 1 adn 100 !")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}