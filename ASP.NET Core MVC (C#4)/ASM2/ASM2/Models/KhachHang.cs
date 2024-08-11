namespace ASM2.Models
{
    public class KhachHang
    {
        public Guid Id { get; set; }
        public string? HoTen { get; set; }
        public int Tuoi { get; set; }
        public string? DiaChi { get; set; }

        public List<DonHang>? DonHangs { get; set; }
    }
}
