using Core.Entities.Consultations;
using Core.Entities.Consultations.Examinations;
using Core.Entities.Family;
using Core.Entities.Informations;
using Core.Entities.Patients;
using Core.Entities.Schedule;
using Microsoft.EntityFrameworkCore;
using System;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CabinetContext : DbContext
    {

        //public DbSet<Father> Fathers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<PatientParent> PatientParents { get; set; }
        // public DbSet<Mother> Mothers { get; set; }
        //   public DbSet<Sister> Sisters { get; set; }
        //   public DbSet<Brother> Brothers { get; set; }
        public DbSet<Sibling> Siblings { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Pregnancy> Pregnanicies { get; set; }
        public DbSet<Born> Borns { get; set; }
        //  public DbSet<TypPregnancy> TypPregnancies { get; set; }

        // Schedule
        public DbSet<Appointment> Appointments { get; set; }
        //Consultation
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Mensuration> Mensurations { get; set; }
        public DbSet<Therapie> Thérapies { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Skin> Skins { get; set; }
        public DbSet<Palpation> Palpations { get; set; }
        public DbSet<Articulation> Articulations { get; set; }
        public DbSet<Head> Heads { get; set; }
        public DbSet<AuscultationCardioPulmonaire> AuscultationCardioPulmonaires { get; set; }
        public DbSet<Abdomen> Abdomens { get; set; }
        public DbSet<Oge> Oges { get; set; }
        public DbSet<Neurologique> Neurologiques { get; set; }
        public DbSet<Rots> Rots { get; set; }

        public CabinetContext(DbContextOptions<CabinetContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>()
                        .HasDiscriminator<string>("ParentsType")
                        .HasValue<Father>("Father")
                        .HasValue<Mother>("Mother");

            modelBuilder.Entity<Sibling>()
                        .HasDiscriminator<string>("SiblingType")
                        .HasValue<Sister>("Sister")
                        .HasValue<Brother>("Brother");

            modelBuilder.Entity<Patient>()
            .HasMany(p => p.Consultations)
            .WithOne(b => b.Patient);

            // Use the shadow property as a foreign key
            modelBuilder.Entity<Sibling>()
                .Property<int>("PatientId");

            modelBuilder.Entity<Sibling>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.Siblings)
                .HasForeignKey("PatientId");

            // Use the shadow property as a foreign key

            modelBuilder.Entity<PatientParent>()
             .Property<int>("PatientId");
            modelBuilder.Entity<PatientParent>()
             .Property<int>("ParentId");

            modelBuilder.Entity<PatientParent>()
                .HasAlternateKey("PatientId", "ParentId");

            modelBuilder.Entity<PatientParent>()
                .HasOne(pp => pp.Patient)
                .WithMany(p => p.PatientParents)
                .HasForeignKey("PatientId");

            modelBuilder.Entity<PatientParent>()
                .HasOne(pp => pp.Parent)
                .WithMany(p => p.PatientParents)
                .HasForeignKey("ParentId");

            //var navigation = modelBuilder.Entity<Patient>().Metadata.FindNavigation(nameof(Patient.Parents));

            //navigation.SetPropertyAccessMode(PropertyAccessMode.Field);



            //modelBuilder
            //    .Entity<Pregnancy>()
            //    .Property(e => e.TypPregnancy)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (TypPregnancy)Enum.Parse(typeof(TypPregnancy), v));

            //modelBuilder
            //    .Entity<Pregnancy>()
            //    .Property(e => e.TypPosition)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (TypPosition)Enum.Parse(typeof(TypPosition), v));

            //modelBuilder
            //    .Entity<Born>()
            //    .Property(e => e.Allaitement)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (Allaitement)Enum.Parse(typeof(Allaitement), v));

            //Consultations
            modelBuilder.Entity<Mensuration>()
               .Property<int>("ConsultationId");

            modelBuilder.Entity<Mensuration>()
                .HasOne(p => p.Consultation)
                .WithOne(p => p.Mensuration)
                .HasForeignKey<Mensuration>("ConsultationId");

            modelBuilder.Entity<Examination>()
               .Property<int>("ConsultationId");

            modelBuilder.Entity<Examination>()
                .HasOne(p => p.Consultation)
                .WithOne(p => p.Examination)
                .HasForeignKey<Examination>("ConsultationId");

            modelBuilder.Entity<Therapie>()
               .Property<int>("ConsultationId");

            modelBuilder.Entity<Therapie>()
                .HasOne(p => p.Consultation)
                .WithOne(p => p.Therapie)
                .HasForeignKey<Therapie>("ConsultationId");

            //Examination
            modelBuilder.Entity<Inspection>()
              .Property<int>("ExaminationId");

            modelBuilder.Entity<Inspection>()
                .HasOne(p => p.Examination)
                .WithOne(p => p.Inspection)
                .HasForeignKey<Inspection>("ExaminationId");

            modelBuilder.Entity<Skin>()
              .Property<int>("ExaminationId");

            modelBuilder.Entity<Skin>()
                .HasOne(p => p.Examination)
                .WithOne(p => p.Skin)
                .HasForeignKey<Skin>("ExaminationId");

            modelBuilder.Entity<Palpation>()
              .Property<int>("ExaminationId");

            modelBuilder.Entity<Palpation>()
                .HasOne(p => p.Examination)
                .WithOne(p => p.Palpation)
                .HasForeignKey<Palpation>("ExaminationId");

            modelBuilder.Entity<Articulation>()
              .Property<int>("ExaminationId");

            modelBuilder.Entity<Articulation>()
                .HasOne(p => p.Examination)
                .WithOne(p => p.Articulation)
                .HasForeignKey<Articulation>("ExaminationId");

            modelBuilder.Entity<Head>()
              .Property<int>("ExaminationId");

            modelBuilder.Entity<Head>()
                .HasOne(p => p.Examination)
                .WithOne(p => p.Head)
                .HasForeignKey<Head>("ExaminationId");

            modelBuilder.Entity<AuscultationCardioPulmonaire>()
              .Property<int>("ExaminationId");

            modelBuilder.Entity<AuscultationCardioPulmonaire>()
                .HasOne(p => p.Examination)
                .WithOne(p => p.AuscultationCardioPulmonaire)
                .HasForeignKey<AuscultationCardioPulmonaire>("ExaminationId");

            modelBuilder.Entity<Abdomen>()
              .Property<int>("ExaminationId");

            modelBuilder.Entity<Abdomen>()
                .HasOne(p => p.Examination)
                .WithOne(p => p.Abdomen)
                .HasForeignKey<Abdomen>("ExaminationId");

            modelBuilder.Entity<Oge>()
              .Property<int>("ExaminationId");

            modelBuilder.Entity<Oge>()
                .HasOne(p => p.Examination)
                .WithOne(p => p.Oge)
                .HasForeignKey<Oge>("ExaminationId");

            modelBuilder.Entity<Neurologique>()
              .Property<int>("ExaminationId");

            modelBuilder.Entity<Neurologique>()
                .HasOne(p => p.Examination)
                .WithOne(p => p.Neurologique)
                .HasForeignKey<Neurologique>("ExaminationId");

            modelBuilder.Entity<Rots>()
              .Property<int>("NeurologiqueId");

            modelBuilder.Entity<Rots>()
                .HasOne(p => p.Neurologique)
                .WithOne(p => p.Rots)
                .HasForeignKey<Rots>("NeurologiqueId");

            // Enums
            modelBuilder
                .Entity<Pregnancy>()
                .Property(e => e.TypPregnancy)
                .HasConversion(
                    v => v.ToString(),
                    v => (TypPregnancy)Enum.Parse(typeof(TypPregnancy), v));

            modelBuilder
                .Entity<Pregnancy>()
                .Property(e => e.TypPosition)
                .HasConversion(
                    v => v.ToString(),
                    v => (TypPosition)Enum.Parse(typeof(TypPosition), v));

            modelBuilder
                .Entity<Born>()
                .Property(e => e.Allaitement)
                .HasConversion(
                    v => v.ToString(),
                    v => (Allaitement)Enum.Parse(typeof(Allaitement), v));

            modelBuilder
                .Entity<Abdomen>()
                .Property(e => e.Vessie)
                .HasConversion(
                    v => v.ToString(),
                    v => (Vessie)Enum.Parse(typeof(Vessie), v));

            modelBuilder
               .Entity<Articulation>()
               .Property(e => e.Ortolani)
               .HasConversion(
                   v => v.ToString(),
                   v => (Ortolani)Enum.Parse(typeof(Ortolani), v));

            modelBuilder
               .Entity<AuscultationCardioPulmonaire>()
               .Property(e => e.RythmeCardiaque)
               .HasConversion(
                   v => v.ToString(),
                   v => (RythmeCardiaque)Enum.Parse(typeof(RythmeCardiaque), v));

            modelBuilder
               .Entity<Inspection>()
               .Property(e => e.EtatDeConscience)
               .HasConversion(
                   v => v.ToString(),
                   v => (EtatDeConscience)Enum.Parse(typeof(EtatDeConscience), v));
            modelBuilder
               .Entity<Inspection>()
               .Property(e => e.EtatGeneral)
               .HasConversion(
                   v => v.ToString(),
                   v => (EtatGeneral)Enum.Parse(typeof(EtatGeneral), v));
            modelBuilder
               .Entity<Inspection>()
               .Property(e => e.EtatHydratation)
               .HasConversion(
                   v => v.ToString(),
                   v => (EtatHydratation)Enum.Parse(typeof(EtatHydratation), v));
            modelBuilder
               .Entity<Inspection>()
               .Property(e => e.StadeDéshydratation)
               .HasConversion(
                   v => v.ToString(),
                   v => (StadeDéshydratation)Enum.Parse(typeof(StadeDéshydratation), v));
            modelBuilder
               .Entity<Inspection>()
               .Property(e => e.Respiratoire)
               .HasConversion(
                   v => v.ToString(),
                   v => (Respiratoire)Enum.Parse(typeof(Respiratoire), v));


            modelBuilder
               .Entity<Oge>()
               .Property(e => e.Sex)
               .HasConversion(
                   v => v.ToString(),
                   v => (Sex)Enum.Parse(typeof(Sex), v));

            modelBuilder
               .Entity<Skin>()
               .Property(e => e.SkinColor)
               .HasConversion(
                   v => v.ToString(),
                   v => (SkinColor)Enum.Parse(typeof(SkinColor), v));

            modelBuilder
               .Entity<Skin>()
               .Property(e => e.Tr)
               .HasConversion(
                   v => v.ToString(),
                   v => (Tr)Enum.Parse(typeof(Tr), v));

            modelBuilder
               .Entity<Skin>()
               .Property(e => e.IctereIntensité)
               .HasConversion(
                   v => v.ToString(),
                   v => (IctereIntensité)Enum.Parse(typeof(IctereIntensité), v));
        }
    }
}
