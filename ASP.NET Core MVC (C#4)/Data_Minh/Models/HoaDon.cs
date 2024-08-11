using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Minh.Models
{
    public class HoaDon
    {
        [Key]
        public Guid id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalMoney { get; set; }
        public int status { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
        public virtual NguoiDung nguoiDung { get; set; }
    }
}
