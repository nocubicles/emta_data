﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using estonian_companies;

namespace estonian_companies.Migrations
{
    [DbContext(typeof(CustomerDataContext))]
    partial class CustomerDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("estonian_companies.CustomerData", b =>
                {
                    b.Property<string>("RegistryCode")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quarter")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("EmployeeCount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("RegisteredVAT")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Revenue")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("StateTax")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("WorkforceTax")
                        .HasColumnType("TEXT");

                    b.Property<string>("YearQuarter")
                        .HasColumnType("TEXT");

                    b.HasKey("RegistryCode", "Year", "Quarter");

                    b.ToTable("customerData");
                });
#pragma warning restore 612, 618
        }
    }
}
