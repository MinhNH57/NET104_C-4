﻿// <auto-generated />
using System;
using DeThiThuLan1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeThiThuLan1.Migrations
{
    [DbContext(typeof(DonHangDbContext))]
    partial class DonHangDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DeThiThuLan1.Models.DonHang", b =>
                {
                    b.Property<string>("MaDonHang")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenDonHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("khachhangID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MaDonHang");

                    b.HasIndex("khachhangID");

                    b.ToTable("DonHangs");

                    b.HasData(
                        new
                        {
                            MaDonHang = "DH01",
                            NgayDat = new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenDonHang = "Giay"
                        });
                });

            modelBuilder.Entity("DeThiThuLan1.Models.KhachHang", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tuoi")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("KhachHangs");

                    b.HasData(
                        new
                        {
                            ID = new Guid("b661f182-772d-42c0-8809-e124d47370ce"),
                            DiaChi = "Vinh Loc",
                            Name = "Nguyen Hong Minh",
                            Tuoi = 20
                        });
                });

            modelBuilder.Entity("DeThiThuLan1.Models.DonHang", b =>
                {
                    b.HasOne("DeThiThuLan1.Models.KhachHang", "khachhang")
                        .WithMany("donHangs")
                        .HasForeignKey("khachhangID");

                    b.Navigation("khachhang");
                });

            modelBuilder.Entity("DeThiThuLan1.Models.KhachHang", b =>
                {
                    b.Navigation("donHangs");
                });
#pragma warning restore 612, 618
        }
    }
}
