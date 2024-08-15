namespace DeThiThuLan1.Models
{
    public class KhachHang
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Tuoi { get; set; }
        public string DiaChi { get; set; }

        public virtual ICollection<DonHang>? donHangs { get; set; }

    }
}
