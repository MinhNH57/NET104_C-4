namespace LuyenTap2.Models
{
    public class SinhVien
    {
        //ID: Guid, HoTen: string, Tuoi: int, ChuyenNganh: string 
        public Guid ID { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string ChuyenNghanh { get; set; }

        public virtual KhoaHoc? khoahoc { get; set; }
    }
}
