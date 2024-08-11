using System.ComponentModel.DataAnnotations;

namespace ASM2.Models
{
    public class DonHang
    {
        [Key]
        [Required]
        public string MaDonHang { get; set; }
        public string? TenDonHang { get; set; }
        public DateTime NgayDat { get; set; }

        public KhachHang? khachhang { get; set; }
    }
}
