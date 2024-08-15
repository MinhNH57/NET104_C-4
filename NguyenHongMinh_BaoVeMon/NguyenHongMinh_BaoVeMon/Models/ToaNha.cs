using System.ComponentModel.DataAnnotations;

namespace NguyenHongMinh_BaoVeMon.Models
{
    public class ToaNha
    {
        //ID string, Diachi: string
        [Key]
        public string ID { get; set; }
        public string DiaChi { get; set; }

        public virtual ICollection<CanHo> CanHos { get; set; }
    }
}
