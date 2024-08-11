using Data_Minh.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Minh.Configurations
{
    public class HoaDonConfig : IEntityTypeConfiguration<HoaDon>
    {
        void IEntityTypeConfiguration<HoaDon>.Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.HasKey(x => x.id); // config khóa chính
            //config khóa ngoại
            builder.HasOne(x => x.nguoiDung).WithMany(x => x.HoaDons)
                .HasForeignKey(x => x.UserId).HasConstraintName("FK_User_HD");
        }
    }
}
