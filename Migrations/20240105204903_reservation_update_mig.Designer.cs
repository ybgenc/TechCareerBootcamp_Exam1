﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechCareerBootcamp_Exam1.Context;

#nullable disable

namespace TechCareerBootcamp_Exam1.Migrations
{
    [DbContext(typeof(ExamContext))]
    [Migration("20240105204903_reservation_update_mig")]
    partial class reservation_update_mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TechCareerBootcamp_Exam1.Models.BaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BaseModels");
                });

            modelBuilder.Entity("TechCareerBootcamp_Exam1.Models.Client", b =>
                {
                    b.HasBaseType("TechCareerBootcamp_Exam1.Models.BaseModel");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("CompanyId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("TechCareerBootcamp_Exam1.Models.Company", b =>
                {
                    b.HasBaseType("TechCareerBootcamp_Exam1.Models.BaseModel");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("TechCareerBootcamp_Exam1.Models.Reservation", b =>
                {
                    b.HasBaseType("TechCareerBootcamp_Exam1.Models.BaseModel");

                    b.Property<string>("CheckIn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CheckOut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasIndex("ClientId");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("TechCareerBootcamp_Exam1.Models.Room", b =>
                {
                    b.HasBaseType("TechCareerBootcamp_Exam1.Models.BaseModel");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("TechCareerBootcamp_Exam1.Models.Client", b =>
                {
                    b.HasOne("TechCareerBootcamp_Exam1.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechCareerBootcamp_Exam1.Models.BaseModel", null)
                        .WithOne()
                        .HasForeignKey("TechCareerBootcamp_Exam1.Models.Client", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("TechCareerBootcamp_Exam1.Models.Company", b =>
                {
                    b.HasOne("TechCareerBootcamp_Exam1.Models.BaseModel", null)
                        .WithOne()
                        .HasForeignKey("TechCareerBootcamp_Exam1.Models.Company", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechCareerBootcamp_Exam1.Models.Reservation", b =>
                {
                    b.HasOne("TechCareerBootcamp_Exam1.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechCareerBootcamp_Exam1.Models.BaseModel", null)
                        .WithOne()
                        .HasForeignKey("TechCareerBootcamp_Exam1.Models.Reservation", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("TechCareerBootcamp_Exam1.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("TechCareerBootcamp_Exam1.Models.Room", b =>
                {
                    b.HasOne("TechCareerBootcamp_Exam1.Models.BaseModel", null)
                        .WithOne()
                        .HasForeignKey("TechCareerBootcamp_Exam1.Models.Room", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
