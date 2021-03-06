﻿// <auto-generated />
using System;
using CarRentApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRentApi.Migrations
{
    [DbContext(typeof(CarRentApiContext))]
    [Migration("20200305211254_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRentApi.Models.Classes.Car", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarBrandGuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarClassGuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("RegistrationPlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Guid");

                    b.HasIndex("CarBrandGuId");

                    b.HasIndex("CarClassGuId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRentApi.Models.Classes.CarBrand", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Guid");

                    b.ToTable("CarBrands");
                });

            modelBuilder.Entity("CarRentApi.Models.Classes.CarClass", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Guid");

                    b.ToTable("CarClasses");
                });

            modelBuilder.Entity("CarRentApi.Models.Classes.Contract", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarGuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ContractNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CustomerGuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerRemark")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<decimal>("DailyFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InternalRemark")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<decimal>("NoOfRentalDays")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ReservationGuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Guid");

                    b.HasIndex("CarGuId");

                    b.HasIndex("CustomerGuId");

                    b.HasIndex("ReservationGuId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("CarRentApi.Models.Classes.Customer", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("CustomerNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("ZIP")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Guid");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CarRentApi.Models.Classes.DailyFee", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarClassGuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DayFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.HasIndex("CarClassGuId");

                    b.ToTable("DailyFees");
                });

            modelBuilder.Entity("CarRentApi.Models.Classes.Reservation", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarClassGuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerGuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerRemark")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<decimal>("NoOfRentalDays")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ReservationNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ReservationState")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.HasIndex("CarClassGuId");

                    b.HasIndex("CustomerGuId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("CarRentApi.Models.Classes.Car", b =>
                {
                    b.HasOne("CarRentApi.Models.Classes.CarBrand", null)
                        .WithMany()
                        .HasForeignKey("CarBrandGuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarRentApi.Models.Classes.CarClass", null)
                        .WithMany()
                        .HasForeignKey("CarClassGuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRentApi.Models.Classes.Contract", b =>
                {
                    b.HasOne("CarRentApi.Models.Classes.Car", null)
                        .WithMany()
                        .HasForeignKey("CarGuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarRentApi.Models.Classes.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerGuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarRentApi.Models.Classes.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationGuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRentApi.Models.Classes.DailyFee", b =>
                {
                    b.HasOne("CarRentApi.Models.Classes.CarClass", null)
                        .WithMany()
                        .HasForeignKey("CarClassGuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRentApi.Models.Classes.Reservation", b =>
                {
                    b.HasOne("CarRentApi.Models.Classes.CarClass", null)
                        .WithMany()
                        .HasForeignKey("CarClassGuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarRentApi.Models.Classes.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerGuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
