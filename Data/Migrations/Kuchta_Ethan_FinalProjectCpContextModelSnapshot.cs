﻿// <auto-generated />
using System;
using Kuchta_Ethan_FinalProjectCp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kuchta_Ethan_FinalProjectCp.Data.Migrations
{
    [DbContext(typeof(Kuchta_Ethan_FinalProjectCpContext))]
    partial class Kuchta_Ethan_FinalProjectCpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kuchta_Ethan_FinalProjectCp.Models.FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FoodItem");
                });

            modelBuilder.Entity("Kuchta_Ethan_FinalProjectCP.Models.MemberItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Program")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MemberItem");
                });

            modelBuilder.Entity("Kuchta_Ethan_FinalProjectCp.Models.ScheduleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proffesor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SessionDays")
                        .HasColumnType("int");

                    b.Property<int>("SessionHours")
                        .HasColumnType("int");

                    b.Property<int>("SessionMins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ScheduleItem");
                });

            modelBuilder.Entity("Kuchta_Ethan_FinalProjectCp.Models.WorkoutItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<string>("TargetMuscle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkoutItem");
                });
#pragma warning restore 612, 618
        }
    }
}
