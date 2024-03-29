﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apka2.Data;

#nullable disable

namespace apka2.Migrations
{
    [DbContext(typeof(apka2Context))]
    [Migration("20221216100521_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("apka2.Models.ClinicalCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildingNumber")
                        .HasColumnType("int");

                    b.Property<string>("CenterDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocalNumber")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClinicalCenter");
                });

            modelBuilder.Entity("apka2.Models.ClinicalDiagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClinicalDiagnosis");
                });

            modelBuilder.Entity("apka2.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("apka2.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasLiverFailure")
                        .HasColumnType("bit");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<DateTime>("HospitalizationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Initials")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartOfCKRTDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("apka2.Models.Servey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AKI")
                        .HasColumnType("bit");

                    b.Property<string>("Anticoagulation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Anuria")
                        .HasColumnType("bit");

                    b.Property<bool>("ArterialHypertension")
                        .HasColumnType("bit");

                    b.Property<int>("CatheterLength")
                        .HasColumnType("int");

                    b.Property<decimal>("CatheterThickness")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Creatinine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<bool>("ECMO")
                        .HasColumnType("bit");

                    b.Property<bool>("ExogenousPoison")
                        .HasColumnType("bit");

                    b.Property<bool>("IonDisorder")
                        .HasColumnType("bit");

                    b.Property<bool>("LowerNephroneSyndrom")
                        .HasColumnType("bit");

                    b.Property<bool>("MetabolicAcidosis")
                        .HasColumnType("bit");

                    b.Property<bool>("Overhydration")
                        .HasColumnType("bit");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<bool>("SepticShock")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ServeyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TypeOfVascularAccess")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Urea")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VascularAccessSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Servey");
                });
#pragma warning restore 612, 618
        }
    }
}
