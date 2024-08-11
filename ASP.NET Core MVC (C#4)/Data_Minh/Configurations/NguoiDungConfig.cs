using Data_Minh.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data_Minh.Configurations
{
    internal class NguoiDungConfig : IEntityTypeConfiguration<NguoiDung>
    {
        void IEntityTypeConfiguration<NguoiDung>.Configure(EntityTypeBuilder<NguoiDung> builder)
        {
            builder.HasKey(x => x.ID);
            //cấu hình cho thuộc
            builder.Property(x => x.Password).HasColumnName("MatKhau")
                .HasColumnType("varchar(50)");
            builder.Property(x => x.Address).IsUnicode(true)
                .IsFixedLength(true).HasMaxLength(256);
        }
    }
}
