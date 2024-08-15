using System.ComponentModel.DataAnnotations;

namespace DeThiThuLan1.Models
{
    public class DonHang
    {
        [Key]
        public string MaDonHang { get; set; }
        public string TenDonHang { get;set; }
        public DateTime NgayDat { get; set; }
        public virtual KhachHang? khachhang { get; set; }
    }
}
