using System.ComponentModel.DataAnnotations;

namespace Practice02.Models
{
    public class Watch
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Origin { get; set; }
        [Required]
        public double Price { get; set; }
        public int year { get; set; }

        public string Img { get; set; }
    }
}
