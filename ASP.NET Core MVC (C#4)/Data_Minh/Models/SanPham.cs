using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Minh.Models
{
    public class SanPham
    {
           [Key]
           public Guid Id { get; set; }
           public string Name { get; set; }
           public decimal Gia { get; set; }
           public Guid IDHoaDon { get; set; }

        public virtual HoaDon Hoadon { get; set; }
    }
}
