﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskAPI.Persistent.Data;

#nullable disable

namespace TaskAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240928094305_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskAPI.App.ErrorLogs.ErrorLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOccurred")
                        .HasColumnType("datetime2");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("QueryString")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("StackTrace")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.HasKey("Id");

                    b.ToTable("ErrorLogs");
                });

            modelBuilder.Entity("TaskAPI.App.PersonRelationships.PersonRelationship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FirstPersonId")
                        .HasColumnType("int");

                    b.Property<int>("SecondPersonId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstPersonId");

                    b.HasIndex("SecondPersonId");

                    b.ToTable("PersonRelationships");
                });

            modelBuilder.Entity("TaskAPI.App.PhoneNumbers.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("TaskAPI.App.PhysicalPersons.PhysicalPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("char(11)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("PhysicalPersons");
                });

            modelBuilder.Entity("TaskAPI.App.PersonRelationships.PersonRelationship", b =>
                {
                    b.HasOne("TaskAPI.App.PhysicalPersons.PhysicalPerson", null)
                        .WithMany()
                        .HasForeignKey("FirstPersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskAPI.App.PhysicalPersons.PhysicalPerson", null)
                        .WithMany()
                        .HasForeignKey("SecondPersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskAPI.App.PhoneNumbers.PhoneNumber", b =>
                {
                    b.HasOne("TaskAPI.App.PhysicalPersons.PhysicalPerson", null)
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskAPI.App.PhysicalPersons.PhysicalPerson", b =>
                {
                    b.Navigation("PhoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}