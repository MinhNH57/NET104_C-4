using System.ComponentModel.DataAnnotations;

namespace LuyenTap2.Models
{
    public class KhoaHoc
    {
        //MaKhoa: string, TenKhoa: string, NamHoc: int
        [Key]
        public string MaKhoaHoc { get; set; }
        public string KhoaHocName { get; set; }
        public int NamHoc { get; set; }

        public virtual ICollection<SinhVien>? SinhViens { get; set; }
    }
}
