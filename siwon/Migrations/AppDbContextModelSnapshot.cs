﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using siwon.Models;

#nullable disable

namespace siwon.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("siwon.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Henryk Sienkiewicz",
                            CreateDate = new DateTime(2022, 11, 9, 9, 28, 41, 40, DateTimeKind.Local).AddTicks(1298),
                            Title = "W pustyni i w puszczy"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Adam Mickiewicz",
                            CreateDate = new DateTime(2022, 11, 9, 9, 28, 41, 40, DateTimeKind.Local).AddTicks(1334),
                            Title = "Pan Tadeusz"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Adam Mickiewicz",
                            CreateDate = new DateTime(2022, 11, 9, 9, 28, 41, 40, DateTimeKind.Local).AddTicks(1336),
                            Title = "Dziady"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Bolesław Prus",
                            CreateDate = new DateTime(2022, 11, 9, 9, 28, 41, 40, DateTimeKind.Local).AddTicks(1338),
                            Title = "Lalka"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
