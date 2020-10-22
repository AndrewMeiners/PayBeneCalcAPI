﻿// <auto-generated />
using BenefitsCalculatorAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BenefitsCalculatorAPI.Migrations
{
    [DbContext(typeof(BenefitsDBContext))]
    partial class BenefitsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BenefitsCalculatorAPI.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("dependentCount")
                        .HasColumnType("int");

                    b.Property<string>("employeeName")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
