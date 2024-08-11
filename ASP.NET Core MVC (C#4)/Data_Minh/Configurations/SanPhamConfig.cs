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
    internal class SanPhamConfig : IEntityTypeConfiguration<SanPham>
    {
        void IEntityTypeConfiguration<SanPham>.Configure(EntityTypeBuilder<SanPham> builder)
        {
            // Khoa chinh 
            builder.HasKey(x => x.Id);
        }
    }
}
