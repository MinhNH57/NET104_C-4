using System.ComponentModel.DataAnnotations;

namespace ASM1.Models
{
    public class LopHoc
    {
        //MaLop string, TenLop: string
        [Key]
        public string MaLop { get; set; }

        public string TenLop { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
