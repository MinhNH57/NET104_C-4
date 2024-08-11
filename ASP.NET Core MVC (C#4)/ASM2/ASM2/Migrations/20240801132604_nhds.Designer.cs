﻿// <auto-generated />
using System;
using ASM2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASM2.Migrations
{
    [DbContext(typeof(MyDbcontext))]
    [Migration("20240801132604_nhds")]
    partial class nhds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ASM2.Models.DonHang", b =>
                {
                    b.Property<string>("MaDonHang")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenDonHang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("khachhangId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MaDonHang");

                    b.HasIndex("khachhangId");

                    b.ToTable("donHangs");

                    b.HasData(
                        new
                        {
                            MaDonHang = "DH01",
                            NgayDat = new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenDonHang = "Sach"
                        });
                });

            modelBuilder.Entity("ASM2.Models.KhachHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tuoi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("khachHangs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("14cfb6d5-52b5-4cb6-a4ab-61e028a776e5"),
                            DiaChi = "Vinh Loc - Phung Xa",
                            HoTen = "Nguyen Hong Minh",
                            Tuoi = 20
                        });
                });

            modelBuilder.Entity("ASM2.Models.DonHang", b =>
                {
                    b.HasOne("ASM2.Models.KhachHang", "khachhang")
                        .WithMany("DonHangs")
                        .HasForeignKey("khachhangId");

                    b.Navigation("khachhang");
                });

            modelBuilder.Entity("ASM2.Models.KhachHang", b =>
                {
                    b.Navigation("DonHangs");
                });
#pragma warning restore 612, 618
        }
    }
}
