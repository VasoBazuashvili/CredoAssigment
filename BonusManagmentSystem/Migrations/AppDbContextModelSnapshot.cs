﻿// <auto-generated />
using System;
using BonusManagmentSystem.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BonusManagmentSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BonusManagmentSystem.Models.Bonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateIssued")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Bonuses");
                });

            modelBuilder.Entity("BonusManagmentSystem.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EmploymentStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecommenderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Remuneration")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("RecommenderId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BonusManagmentSystem.Models.Bonus", b =>
                {
                    b.HasOne("BonusManagmentSystem.Models.Employee", "Employee")
                        .WithMany("BonusesReceived")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BonusManagmentSystem.Models.Employee", b =>
                {
                    b.HasOne("BonusManagmentSystem.Models.Employee", "Recommender")
                        .WithMany()
                        .HasForeignKey("RecommenderId");

                    b.Navigation("Recommender");
                });

            modelBuilder.Entity("BonusManagmentSystem.Models.Employee", b =>
                {
                    b.Navigation("BonusesReceived");
                });
#pragma warning restore 612, 618
        }
    }
}
