﻿// <auto-generated />
using DealershipManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DealershipManager.Migrations
{
    [DbContext(typeof(DealershipManagerContext))]
    [Migration("20220105181611_UpdateInitial1")]
    partial class UpdateInitial1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DealershipManager.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Model")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("DealershipManager.Models.CarDealership", b =>
                {
                    b.Property<int>("CarDealershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("DealershipId")
                        .HasColumnType("int");

                    b.HasKey("CarDealershipId");

                    b.HasIndex("CarId");

                    b.HasIndex("DealershipId");

                    b.ToTable("CarDealership");
                });

            modelBuilder.Entity("DealershipManager.Models.Dealership", b =>
                {
                    b.Property<int>("DealershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("DealershipId");

                    b.ToTable("Dealerships");
                });

            modelBuilder.Entity("DealershipManager.Models.DealershipSalesman", b =>
                {
                    b.Property<int>("DealershipSalesmanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DealershipId")
                        .HasColumnType("int");

                    b.Property<int>("SalesmanId")
                        .HasColumnType("int");

                    b.HasKey("DealershipSalesmanId");

                    b.HasIndex("DealershipId");

                    b.HasIndex("SalesmanId");

                    b.ToTable("DealershipSalesman");
                });

            modelBuilder.Entity("DealershipManager.Models.Salesman", b =>
                {
                    b.Property<int>("SalesmanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SalesmanId");

                    b.ToTable("Salesmen");
                });

            modelBuilder.Entity("DealershipManager.Models.CarDealership", b =>
                {
                    b.HasOne("DealershipManager.Models.Car", "Car")
                        .WithMany("JoinEntities")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DealershipManager.Models.Dealership", "Dealership")
                        .WithMany("CarEntities")
                        .HasForeignKey("DealershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Dealership");
                });

            modelBuilder.Entity("DealershipManager.Models.DealershipSalesman", b =>
                {
                    b.HasOne("DealershipManager.Models.Dealership", "Dealership")
                        .WithMany("SalesmanEntities")
                        .HasForeignKey("DealershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DealershipManager.Models.Salesman", "Salesman")
                        .WithMany("JoinEntities")
                        .HasForeignKey("SalesmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dealership");

                    b.Navigation("Salesman");
                });

            modelBuilder.Entity("DealershipManager.Models.Car", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("DealershipManager.Models.Dealership", b =>
                {
                    b.Navigation("CarEntities");

                    b.Navigation("SalesmanEntities");
                });

            modelBuilder.Entity("DealershipManager.Models.Salesman", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
