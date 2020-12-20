﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NameApp.Server.Data;

namespace NameApp.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201220102134_LuotiinTietokanta")]
    partial class LuotiinTietokanta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("NameApp.Shared.Name", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nimi")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Names");
                });
#pragma warning restore 612, 618
        }
    }
}
