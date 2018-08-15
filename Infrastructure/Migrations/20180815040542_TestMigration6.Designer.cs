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
    [Migration("20180815040542_TestMigration6")]
    partial class TestMigration6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Born", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Allaitement");

                    b.Property<int>("Apgar1mn");

                    b.Property<int>("Apgar5mn");

                    b.Property<int>("BirthWeight");

                    b.Property<bool>("Cry");

                    b.Property<string>("RemarqueAllaitement");

                    b.HasKey("Id");

                    b.ToTable("Borns");
                });

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

                    b.Property<int?>("Tel");

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

                    b.Property<int?>("MotherId");

                    b.Property<string>("Name");

                    b.Property<int?>("PreganancyId");

                    b.Property<int?>("Tel");

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

                    b.Property<int>("Day");

                    b.Property<int>("Position");

                    b.Property<int>("TypPregnancy");

                    b.Property<int>("Week");

                    b.HasKey("Id");

                    b.ToTable("Pregnanicies");
                });

            modelBuilder.Entity("Core.Entities.Sibling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<bool>("Health");

                    b.Property<bool>("Information");

                    b.Property<int?>("PatientId");

                    b.Property<string>("SiblingType")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Siblings");

                    b.HasDiscriminator<string>("SiblingType").HasValue("Sibling");
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

            modelBuilder.Entity("Core.Entities.Brother", b =>
                {
                    b.HasBaseType("Core.Entities.Sibling");


                    b.ToTable("Brother");

                    b.HasDiscriminator().HasValue("Brother");
                });

            modelBuilder.Entity("Core.Entities.Sister", b =>
                {
                    b.HasBaseType("Core.Entities.Sibling");


                    b.ToTable("Sister");

                    b.HasDiscriminator().HasValue("Sister");
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

            modelBuilder.Entity("Core.Entities.Sibling", b =>
                {
                    b.HasOne("Core.Entities.Patient")
                        .WithMany("Siblings")
                        .HasForeignKey("PatientId");
                });
#pragma warning restore 612, 618
        }
    }
}
