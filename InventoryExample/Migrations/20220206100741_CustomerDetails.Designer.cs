﻿// <auto-generated />
using System;
using InventoryExample.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryExample.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220206100741_CustomerDetails")]
    partial class CustomerDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InventoryExample.Entities.Product", b =>
                {
                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ReOrderLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("ProductCode");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("InventoryExample.Entities.PurchaseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PurchaseHeaderid")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProductCode");

                    b.HasIndex("PurchaseHeaderid");

                    b.ToTable("PurchaseDetails");
                });

            modelBuilder.Entity("InventoryExample.Entities.PurchaseHeader", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PurchaseInvoiceStatus")
                        .HasColumnType("bit");

                    b.Property<double>("PurchaseTotal")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("PurchaseHeaders");
                });

            modelBuilder.Entity("InventoryExample.Entities.SaleDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SaleHeaderid")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProductCode");

                    b.HasIndex("SaleHeaderid");

                    b.ToTable("SaleDetails");
                });

            modelBuilder.Entity("InventoryExample.Entities.SaleHeader", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("InvoiceStatus")
                        .HasColumnType("bit");

                    b.Property<double>("InvoiceTotal")
                        .HasColumnType("float");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("SaleHeaders");
                });

            modelBuilder.Entity("InventoryExample.Entities.PurchaseDetail", b =>
                {
                    b.HasOne("InventoryExample.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductCode");

                    b.HasOne("InventoryExample.Entities.PurchaseHeader", "PurchaseHeader")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("PurchaseHeaderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("PurchaseHeader");
                });

            modelBuilder.Entity("InventoryExample.Entities.SaleDetails", b =>
                {
                    b.HasOne("InventoryExample.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductCode");

                    b.HasOne("InventoryExample.Entities.SaleHeader", "SaleHeader")
                        .WithMany("SaleDetails")
                        .HasForeignKey("SaleHeaderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SaleHeader");
                });

            modelBuilder.Entity("InventoryExample.Entities.PurchaseHeader", b =>
                {
                    b.Navigation("PurchaseDetails");
                });

            modelBuilder.Entity("InventoryExample.Entities.SaleHeader", b =>
                {
                    b.Navigation("SaleDetails");
                });
#pragma warning restore 612, 618
        }
    }
}