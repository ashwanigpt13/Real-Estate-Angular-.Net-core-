﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240531060445_SeedingData")]
    partial class SeedingData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(2);

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "USA",
                            LastUpdatedBy = 1,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8988),
                            Name = "New York"
                        },
                        new
                        {
                            Id = 2,
                            Country = "USA",
                            LastUpdatedBy = 1,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8991),
                            Name = "Houston"
                        },
                        new
                        {
                            Id = 3,
                            Country = "USA",
                            LastUpdatedBy = 1,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8993),
                            Name = "Los Angeles"
                        },
                        new
                        {
                            Id = 4,
                            Country = "India",
                            LastUpdatedBy = 1,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8995),
                            Name = "New Delhi"
                        },
                        new
                        {
                            Id = 5,
                            Country = "India",
                            LastUpdatedBy = 1,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8997),
                            Name = "Bangalore"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.FurnishingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FurnishingTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastUpdatedBy = 1,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8950),
                            Name = "Fully"
                        },
                        new
                        {
                            Id = 2,
                            LastUpdatedBy = 1,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8953),
                            Name = "Semi"
                        },
                        new
                        {
                            Id = 3,
                            LastUpdatedBy = 1,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8955),
                            Name = "Unfurnished"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("WebAPI.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("BHK")
                        .HasColumnType("int");

                    b.Property<int?>("BuiltArea")
                        .HasColumnType("int");

                    b.Property<int>("CarpetArea")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EstPossessionOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("FloorNo")
                        .HasColumnType("int");

                    b.Property<int>("FurnishingTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Gated")
                        .HasColumnType("bit");

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("MainEntrance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Maintenance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int>("PropertyTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("ReadyToMove")
                        .HasColumnType("bit");

                    b.Property<int?>("Security")
                        .HasColumnType("int");

                    b.Property<int>("SellRent")
                        .HasColumnType("int");

                    b.Property<int?>("TotalFloors")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("FurnishingTypeId");

                    b.HasIndex("PostedBy");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Properties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "6 Street",
                            Address2 = "Golf Course Road",
                            Age = 0,
                            BHK = 2,
                            BuiltArea = 1400,
                            CarpetArea = 900,
                            CityId = 1,
                            Description = "Well Maintained builder floor available for rent at prime location...",
                            EstPossessionOn = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FloorNo = 3,
                            FurnishingTypeId = 1,
                            Gated = true,
                            LastUpdatedBy = 0,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(9039),
                            MainEntrance = "East",
                            Maintenance = 300,
                            Name = "White House Demo",
                            PostedBy = 1,
                            PostedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(9057),
                            Price = 1800,
                            PropertyTypeId = 2,
                            ReadyToMove = true,
                            Security = 0,
                            SellRent = 1,
                            TotalFloors = 3
                        },
                        new
                        {
                            Id = 2,
                            Address = "6 Street",
                            Address2 = "Golf Course Road",
                            Age = 0,
                            BHK = 2,
                            BuiltArea = 1400,
                            CarpetArea = 900,
                            CityId = 1,
                            Description = "Well Maintained builder floor available for rent at prime location...",
                            EstPossessionOn = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FloorNo = 3,
                            FurnishingTypeId = 1,
                            Gated = true,
                            LastUpdatedBy = 0,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(9060),
                            MainEntrance = "East",
                            Maintenance = 300,
                            Name = "Birla House Demo",
                            PostedBy = 1,
                            PostedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(9066),
                            Price = 1800,
                            PropertyTypeId = 2,
                            ReadyToMove = true,
                            Security = 0,
                            SellRent = 2,
                            TotalFloors = 3
                        });
                });

            modelBuilder.Entity("WebAPI.Models.PropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PropertyTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastUpdatedBy = 1,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8915),
                            Name = "House"
                        },
                        new
                        {
                            Id = 2,
                            LastUpdatedBy = 1,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8918),
                            Name = "Apartment"
                        },
                        new
                        {
                            Id = 3,
                            LastUpdatedBy = 1,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8920),
                            Name = "Duplex"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastUpdatedBy = 0,
                            LastUpdatedOn = new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8698),
                            Password = new byte[] { 104, 97, 115, 104, 101, 100, 95, 112, 97, 115, 115, 119, 111, 114, 100 },
                            PasswordKey = new byte[] { 104, 97, 115, 104, 101, 100, 95, 112, 97, 115, 115, 119, 111, 114, 100, 95, 107, 101, 121 },
                            Username = "Demo"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Photo", b =>
                {
                    b.HasOne("WebAPI.Models.Property", "Property")
                        .WithMany("Photos")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("WebAPI.Models.Property", b =>
                {
                    b.HasOne("WebAPI.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.FurnishingType", "FurnishingType")
                        .WithMany()
                        .HasForeignKey("FurnishingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("PostedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.PropertyType", "PropertyType")
                        .WithMany()
                        .HasForeignKey("PropertyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("FurnishingType");

                    b.Navigation("PropertyType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAPI.Models.Property", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
