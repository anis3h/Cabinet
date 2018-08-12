﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Pregnancy> c { get; set; }
      //  public DbSet<TypPregnancy> TypPregnancies { get; set; }
        
        public CabinetContext(DbContextOptions<CabinetContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Cabinet;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>()
                        .HasDiscriminator<string>("ParentsType")
                        .HasValue<Father>("Father")
                        .HasValue<Mother>("Mother");

           
            modelBuilder.Entity<Patient>()
            .HasMany(p => p.Consultations)
            .WithOne(b => b.Patient);


        }
    }
}
