﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CabinetContext))]
    partial class CabinetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Consultations.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("Core.Entities.Consultations.Illness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConsultationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.ToTable("Illness");
                });

            modelBuilder.Entity("Core.Entities.Family.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("Core.Entities.Family.PatientParent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParentId");

                    b.Property<int>("PatientId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientParent");
                });

            modelBuilder.Entity("Core.Entities.Family.Sibling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<bool?>("Health");

                    b.Property<string>("Information");

                    b.Property<int>("PatientId");

                    b.Property<string>("SiblingType")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Siblings");

                    b.HasDiscriminator<string>("SiblingType").HasValue("Sibling");
                });

            modelBuilder.Entity("Core.Entities.Informations.Born", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Allaitement");

                    b.Property<int>("Apgar1mn");

                    b.Property<int>("Apgar5mn");

                    b.Property<int>("BirthWeight");

                    b.Property<bool>("Cry");

                    b.Property<string>("RemarqueAllaitement");

                    b.HasKey("Id");

                    b.ToTable("Borns");
                });

            modelBuilder.Entity("Core.Entities.Informations.Pregnancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Day");

                    b.Property<string>("TypPosition")
                        .IsRequired();

                    b.Property<string>("TypPregnancy")
                        .IsRequired();

                    b.Property<int>("Week");

                    b.HasKey("Id");

                    b.ToTable("Pregnanicies");
                });

            modelBuilder.Entity("Core.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse");

                    b.Property<int?>("BornId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("Name");

                    b.Property<int?>("PregnancyId");

                    b.Property<int?>("Tel");

                    b.HasKey("Id");

                    b.HasIndex("BornId");

                    b.HasIndex("PregnancyId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Core.Entities.Family.Father", b =>
                {
                    b.HasBaseType("Core.Entities.Family.Parent");


                    b.ToTable("Father");

                    b.HasDiscriminator().HasValue("Father");
                });

            modelBuilder.Entity("Core.Entities.Family.Mother", b =>
                {
                    b.HasBaseType("Core.Entities.Family.Parent");

                    b.Property<string>("MaidenName");

                    b.ToTable("Mother");

                    b.HasDiscriminator().HasValue("Mother");
                });

            modelBuilder.Entity("Core.Entities.Family.Brother", b =>
                {
                    b.HasBaseType("Core.Entities.Family.Sibling");


                    b.ToTable("Brother");

                    b.HasDiscriminator().HasValue("Brother");
                });

            modelBuilder.Entity("Core.Entities.Family.Sister", b =>
                {
                    b.HasBaseType("Core.Entities.Family.Sibling");


                    b.ToTable("Sister");

                    b.HasDiscriminator().HasValue("Sister");
                });

            modelBuilder.Entity("Core.Entities.Consultations.Consultation", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("Consultations")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("Core.Entities.Consultations.Illness", b =>
                {
                    b.HasOne("Core.Entities.Consultations.Consultation")
                        .WithMany("IllnessList")
                        .HasForeignKey("ConsultationId");
                });

            modelBuilder.Entity("Core.Entities.Family.PatientParent", b =>
                {
                    b.HasOne("Core.Entities.Family.Parent", "Parent")
                        .WithMany("PatientParents")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("PatientParents")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Entities.Family.Sibling", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("Siblings")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Entities.Patient", b =>
                {
                    b.HasOne("Core.Entities.Informations.Born", "Born")
                        .WithMany()
                        .HasForeignKey("BornId");

                    b.HasOne("Core.Entities.Informations.Pregnancy", "Pregnancy")
                        .WithMany()
                        .HasForeignKey("PregnancyId");
                });
#pragma warning restore 612, 618
        }
    }
}
