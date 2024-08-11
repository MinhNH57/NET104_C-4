using System.ComponentModel.DataAnnotations;

namespace Practice_01.Models
{
    public class Product
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }
        public int SoLuong { get; set; }
        public string ImgUrl { get; set; }
    }
}
