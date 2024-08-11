using System.ComponentModel.DataAnnotations;

namespace SD18406.Models
{
    public class Catregory
    {
        [Key]
        public Guid ID {  get; set; }
        [Required]
        public string Name { get; set; }
        public int SoLuong { get; set; }

        public string ImgURL { get; set; }
    }
}
