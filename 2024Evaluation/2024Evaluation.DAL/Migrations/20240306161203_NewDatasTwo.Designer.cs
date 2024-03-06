﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2024Evaluation.DAL;

#nullable disable

namespace _2024Evaluation.DAL.Migrations
{
    [DbContext(typeof(DbContextEntity))]
    [Migration("20240306161203_NewDatasTwo")]
    partial class NewDatasTwo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_2024Evaluation.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "I'm the Description of the first event",
                            Location = "I'm the location of the first event",
                            Time = new TimeSpan(0, 5, 40, 23, 0),
                            Title = "MyFirstEvent"
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "I'm the Description of the second event",
                            Location = "I'm the location of the second event",
                            Time = new TimeSpan(0, 6, 30, 45, 0),
                            Title = "MySecondEvent"
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "I'm the Description of the third event",
                            Location = "I'm the location of the third event",
                            Time = new TimeSpan(0, 7, 20, 10, 0),
                            Title = "MyThirdEvent"
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "I'm the Description of the fourth event",
                            Location = "I'm the location of the fourth event",
                            Time = new TimeSpan(0, 8, 15, 35, 0),
                            Title = "MyFourthEvent"
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "I'm the Description of the fifth event",
                            Location = "I'm the location of the fifth event",
                            Time = new TimeSpan(0, 9, 10, 50, 0),
                            Title = "MyFifthEvent"
                        },
                        new
                        {
                            Id = 6,
                            Date = new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "I'm the Description of the sixth event",
                            Location = "I'm the location of the sixth event",
                            Time = new TimeSpan(0, 10, 5, 15, 0),
                            Title = "MySixthEvent"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}