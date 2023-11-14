﻿// <auto-generated />
using System;
using HotelManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagementSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231113100601_changingRoomNoRequiredProperty2")]
    partial class changingRoomNoRequiredProperty2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelManagementSystem.Models.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartID"));

                    b.Property<int>("CartHotelID")
                        .HasColumnType("int");

                    b.Property<decimal>("CartPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CartRDID")
                        .HasColumnType("int");

                    b.Property<int>("CartRoomID")
                        .HasColumnType("int");

                    b.Property<int>("CartUserID")
                        .HasColumnType("int");

                    b.HasKey("CartID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.Hotels", b =>
                {
                    b.Property<int>("HotelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelID"));

                    b.Property<string>("HotelAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HotelCity")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("HotelEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HotelImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("HotelPhone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("HotelID");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.Invoices", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceID"));

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InvoiceDateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InvoiceDateTo")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InvoiceDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("InvoiceHotelID")
                        .HasColumnType("int");

                    b.Property<decimal>("InvoiceNetPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InvoicePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("InvoiceRDID")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceRoomID")
                        .HasColumnType("int");

                    b.Property<decimal>("InvoiceTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InvoiceTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("InvoiceUserID")
                        .HasColumnType("int");

                    b.HasKey("InvoiceID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.RoomDetails", b =>
                {
                    b.Property<int>("RDID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RDID"));

                    b.Property<string>("RDFeatures")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RDFood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RDHotelID")
                        .HasColumnType("int");

                    b.Property<string>("RDImage1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RDImage2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RDImage3")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RDRoomID")
                        .HasColumnType("int");

                    b.HasKey("RDID");

                    b.ToTable("RoomDetails");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.Rooms", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomID"));

                    b.Property<int>("RoomHotelID")
                        .HasColumnType("int");

                    b.Property<string>("RoomImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("RoomPrice")
                        .HasColumnType("real");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoomID");

                    b.ToTable("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
