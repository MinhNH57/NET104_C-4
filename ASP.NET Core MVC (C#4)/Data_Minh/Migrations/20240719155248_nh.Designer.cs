﻿// <auto-generated />
using System;
using Data_Minh.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data_Minh.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240719155248_nh")]
    partial class nh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data_Minh.Models.HoaDon", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("nguoiDungID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("nguoiDungID");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("Data_Minh.Models.NguoiDung", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(true)
                        .HasColumnType("nchar(256)")
                        .IsFixedLength();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("MatKhau");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("NguoiDungs");
                });

            modelBuilder.Entity("Data_Minh.Models.SanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("Hoadonid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDHoaDon")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Hoadonid");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("Data_Minh.Models.HoaDon", b =>
                {
                    b.HasOne("Data_Minh.Models.NguoiDung", "nguoiDung")
                        .WithMany("HoaDons")
                        .HasForeignKey("nguoiDungID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("nguoiDung");
                });

            modelBuilder.Entity("Data_Minh.Models.SanPham", b =>
                {
                    b.HasOne("Data_Minh.Models.HoaDon", "Hoadon")
                        .WithMany("SanPhams")
                        .HasForeignKey("Hoadonid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hoadon");
                });

            modelBuilder.Entity("Data_Minh.Models.HoaDon", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("Data_Minh.Models.NguoiDung", b =>
                {
                    b.Navigation("HoaDons");
                });
#pragma warning restore 612, 618
        }
    }
}
