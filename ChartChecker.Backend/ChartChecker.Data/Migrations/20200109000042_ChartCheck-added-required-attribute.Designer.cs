﻿// <auto-generated />
using System;
using ChartChecker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChartChecker.Data.Migrations
{
    [DbContext(typeof(ChartCheckerDbContext))]
    [Migration("20200109000042_ChartCheck-added-required-attribute")]
    partial class ChartCheckaddedrequiredattribute
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChartChecker.Models.Database.ChartCheck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChartType")
                        .IsRequired();

                    b.Property<DateTime>("EventDateTime");

                    b.Property<string>("ImagePath")
                        .IsRequired();

                    b.Property<string>("StoreName")
                        .IsRequired();

                    b.Property<string>("UserEmail")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ChartChecks");
                });
#pragma warning restore 612, 618
        }
    }
}