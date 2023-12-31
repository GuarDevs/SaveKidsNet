﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SaveKids.DAL.DbContexts;

#nullable disable

namespace SaveKids.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SaveKids.Domain.Entities.Attachments.Attachment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("SaveKids.Domain.Entities.Crimes.Crime", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CrimeCategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("CriminalId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateOfCrime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Detail")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("PlaceOfCrime")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CrimeCategoryId");

                    b.HasIndex("CriminalId");

                    b.ToTable("Crimes");
                });

            modelBuilder.Entity("SaveKids.Domain.Entities.Crimes.CrimeCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("CrimeCategories");
                });

            modelBuilder.Entity("SaveKids.Domain.Entities.Criminals.Criminal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AttachmentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Detail")
                        .HasColumnType("text");

                    b.Property<string>("Eyes")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Hair")
                        .HasColumnType("text");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Nationatily")
                        .HasColumnType("text");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentId");

                    b.ToTable("Criminals");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2023, 9, 8, 13, 17, 5, 798, DateTimeKind.Utc).AddTicks(5064),
                            DateOfBirth = new DateTime(1964, 9, 6, 19, 0, 0, 0, DateTimeKind.Utc),
                            Detail = "Fields II has a scar on his chest, his groin, his left calf, on both legs and both knees. He also has a tribal print tattoo on his right shoulder.",
                            Eyes = "Hazel",
                            FirstName = "Donald",
                            Gender = "Male",
                            Hair = "Brown",
                            Height = 180.0,
                            IsDeleted = false,
                            LastName = "Eugene Fields II",
                            Nationatily = "White American",
                            PlaceOfBirth = "Kentucky",
                            Weight = 90.0
                        });
                });

            modelBuilder.Entity("SaveKids.Domain.Entities.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("TelNumber")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2023, 9, 8, 13, 17, 5, 798, DateTimeKind.Utc).AddTicks(4901),
                            DateOfBirth = new DateTime(2024, 11, 5, 19, 0, 0, 0, DateTimeKind.Utc),
                            Email = "mansurjonmoydinov16072002@gmail.com",
                            FirstName = "Mansurjon",
                            IsDeleted = false,
                            LastName = "Mo'ydinov",
                            Password = "mansurjon1512",
                            Role = 1,
                            TelNumber = "+998908515979"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2023, 9, 8, 13, 17, 5, 798, DateTimeKind.Utc).AddTicks(4907),
                            DateOfBirth = new DateTime(2024, 1, 7, 19, 0, 0, 0, DateTimeKind.Utc),
                            Email = "turdiyevgmail.com",
                            FirstName = "Muhammadqodir",
                            IsDeleted = false,
                            LastName = "Turdiyev",
                            Password = "mansurjon1512",
                            Role = 2,
                            TelNumber = "+998912031759"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2023, 9, 8, 13, 17, 5, 798, DateTimeKind.Utc).AddTicks(4910),
                            DateOfBirth = new DateTime(2024, 12, 3, 19, 0, 0, 0, DateTimeKind.Utc),
                            Email = "jasurbek@gmail.com",
                            FirstName = "Nurullo",
                            IsDeleted = false,
                            LastName = "Nurmatov",
                            Password = "mansurjon1512",
                            Role = 3,
                            TelNumber = "+99890335578900"
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2023, 9, 8, 13, 17, 5, 798, DateTimeKind.Utc).AddTicks(4913),
                            DateOfBirth = new DateTime(1999, 11, 3, 19, 0, 0, 0, DateTimeKind.Utc),
                            Email = "saidkamolgmail.com",
                            FirstName = "Saidkamol",
                            IsDeleted = false,
                            LastName = "Saidjamolov",
                            Password = "mansurjon1512",
                            Role = 3,
                            TelNumber = "+998908515979"
                        });
                });

            modelBuilder.Entity("SaveKids.Domain.Entities.Crimes.Crime", b =>
                {
                    b.HasOne("SaveKids.Domain.Entities.Crimes.CrimeCategory", "CrimeCategory")
                        .WithMany("Crimes")
                        .HasForeignKey("CrimeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaveKids.Domain.Entities.Criminals.Criminal", "Criminal")
                        .WithMany("Crimes")
                        .HasForeignKey("CriminalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CrimeCategory");

                    b.Navigation("Criminal");
                });

            modelBuilder.Entity("SaveKids.Domain.Entities.Criminals.Criminal", b =>
                {
                    b.HasOne("SaveKids.Domain.Entities.Attachments.Attachment", "Attachment")
                        .WithMany()
                        .HasForeignKey("AttachmentId");

                    b.Navigation("Attachment");
                });

            modelBuilder.Entity("SaveKids.Domain.Entities.Crimes.CrimeCategory", b =>
                {
                    b.Navigation("Crimes");
                });

            modelBuilder.Entity("SaveKids.Domain.Entities.Criminals.Criminal", b =>
                {
                    b.Navigation("Crimes");
                });
#pragma warning restore 612, 618
        }
    }
}
