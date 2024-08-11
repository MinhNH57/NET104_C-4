﻿// <auto-generated />
using System;
using DemoGH_OnTap.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoGH_OnTap.Migrations
{
    [DbContext(typeof(SD18406CartDbContext))]
    [Migration("20240725173747_hi555566666")]
    partial class hi555566666
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemoGH_OnTap.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DemoGH_OnTap.Models.GHCT", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid?>("GioHangId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SanPhamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GioHangId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("GHCTs");
                });

            modelBuilder.Entity("DemoGH_OnTap.Models.GioHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountID")
                        .IsUnique()
                        .HasFilter("[AccountID] IS NOT NULL");

                    b.ToTable("GioHang");
                });

            modelBuilder.Entity("DemoGH_OnTap.Models.SanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("DemoGH_OnTap.Models.GHCT", b =>
                {
                    b.HasOne("DemoGH_OnTap.Models.GioHang", "GioHang")
                        .WithMany("GHCTs")
                        .HasForeignKey("GioHangId");

                    b.HasOne("DemoGH_OnTap.Models.SanPham", "SanPham")
                        .WithMany("GHCTs")
                        .HasForeignKey("SanPhamId");

                    b.Navigation("GioHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("DemoGH_OnTap.Models.GioHang", b =>
                {
                    b.HasOne("DemoGH_OnTap.Models.Account", "Account")
                        .WithOne("GioHang")
                        .HasForeignKey("DemoGH_OnTap.Models.GioHang", "AccountID");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DemoGH_OnTap.Models.Account", b =>
                {
                    b.Navigation("GioHang");
                });

            modelBuilder.Entity("DemoGH_OnTap.Models.GioHang", b =>
                {
                    b.Navigation("GHCTs");
                });

            modelBuilder.Entity("DemoGH_OnTap.Models.SanPham", b =>
                {
                    b.Navigation("GHCTs");
                });
#pragma warning restore 612, 618
        }
    }
}
