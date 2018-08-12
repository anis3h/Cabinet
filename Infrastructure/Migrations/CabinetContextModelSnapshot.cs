﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CabinetContext))]
    partial class CabinetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cut");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Information");

                    b.Property<int?>("PatientId");

                    b.Property<int>("Pc");

                    b.Property<int>("Temperature");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<int>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("Core.Entities.Illness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ConsultationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.ToTable("Illness");
                });

            modelBuilder.Entity("Core.Entities.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresse");

                    b.Property<string>("FirstName");

                    b.Property<string>("Name");

                    b.Property<string>("ParentsType")
                        .IsRequired();

                    b.Property<string>("Profession");

                    b.Property<int>("Tel");

                    b.HasKey("Id");

                    b.ToTable("Parents");

                    b.HasDiscriminator<string>("ParentsType").HasValue("Parent");
                });

            modelBuilder.Entity("Core.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresse");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int?>("FatherId");

                    b.Property<string>("FirstName");

                    b.Property<int>("Fraternity");

                    b.Property<int?>("MotherId");

                    b.Property<string>("Name");

                    b.Property<int?>("PreganancyId");

                    b.Property<int>("Tel");

                    b.HasKey("Id");

                    b.HasIndex("FatherId");

                    b.HasIndex("MotherId");

                    b.HasIndex("PreganancyId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Core.Entities.Pregnancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BirthWeight");

                    b.Property<int>("Day");

                    b.Property<int>("TypPregnancy");

                    b.Property<int>("Week");

                    b.HasKey("Id");

                    b.ToTable("Pregnancies");
                });

            modelBuilder.Entity("Core.Entities.Father", b =>
                {
                    b.HasBaseType("Core.Entities.Parent");


                    b.ToTable("Father");

                    b.HasDiscriminator().HasValue("Father");
                });

            modelBuilder.Entity("Core.Entities.Mother", b =>
                {
                    b.HasBaseType("Core.Entities.Parent");

                    b.Property<string>("MaidenName");

                    b.ToTable("Mother");

                    b.HasDiscriminator().HasValue("Mother");
                });

            modelBuilder.Entity("Core.Entities.Consultation", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("Consultations")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("Core.Entities.Illness", b =>
                {
                    b.HasOne("Core.Entities.Consultation")
                        .WithMany("IllnessList")
                        .HasForeignKey("ConsultationId");
                });

            modelBuilder.Entity("Core.Entities.Patient", b =>
                {
                    b.HasOne("Core.Entities.Father", "Father")
                        .WithMany()
                        .HasForeignKey("FatherId");

                    b.HasOne("Core.Entities.Mother", "Mother")
                        .WithMany()
                        .HasForeignKey("MotherId");

                    b.HasOne("Core.Entities.Pregnancy", "Preganancy")
                        .WithMany()
                        .HasForeignKey("PreganancyId");
                });
#pragma warning restore 612, 618
        }
    }
}
