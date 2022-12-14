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
    [Migration("20221205115010_ProceduresController-fixed")]
    partial class ProceduresControllerfixed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
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

            modelBuilder.Entity("apka2.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasClinicallySignificantCoagulationDisorders")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("apka2.Models.Procedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("BloodWasReturned")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EndedOnSchedule")
                        .HasColumnType("bit");

                    b.Property<bool>("PatientDied")
                        .HasColumnType("bit");

                    b.Property<string>("ReasonOfUnplannedTermination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Procedure");
                });
#pragma warning restore 612, 618
        }
    }
}
