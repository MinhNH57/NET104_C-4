using System.ComponentModel.DataAnnotations;

namespace NguyenHongMinh_BaoVeMon.Models
{
    public class CanHo
    {
        //ID: string, Tên: string, Dientich: double, So: string
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public double DienTich { get; set; }
        public string So { get; set; }

        public virtual ToaNha toaNha { get; set; }
    }
}
