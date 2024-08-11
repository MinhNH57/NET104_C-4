namespace ASM1.Models
{
    public class SinhVien
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }

        public string MaLop { get; set; } // Thay vì khóa ngoại, chỉ cần thuộc tính khóa chính
        public virtual LopHoc Classroom { get; set; } // Mối quan hệ với LopHoc
    }
}
