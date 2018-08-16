using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;


namespace Infrastructure.Data
{
    public class CabinetContext:DbContext
    {
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Father> Fathers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Mother> Mothers { get; set; }
        public DbSet<Sister> Sisters { get; set; }
        public DbSet<Brother> Brothers { get; set; }
        public DbSet<Sibling> Siblings { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Pregnancy> Pregnanicies { get; set; }
        public DbSet<Born> Borns { get; set; }
        //  public DbSet<TypPregnancy> TypPregnancies { get; set; }

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
                

            modelBuilder.Entity<Patient>()
            .HasMany(p => p.Siblings)
            .WithOne(b => b.Patient);

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
        }
    }
}
