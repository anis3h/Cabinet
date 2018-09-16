using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Entities.Family;
using Core.Entities.Informations;
using Core.Entities.Patients;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Repositories
{
    public static class DbInitializer
    {
        public static void Initialize(CabinetContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Patients.Any())
            {
                return;   // DB has been seeded
            }
            var fathers = new List<Father>
            {             
                 new Father {
                    Adresse = "TestAdresse", FirstName = "Vater2Vorname", Name = "Vater2Nachname",
                              Tel = "0123456789", Profession = "Informatiker" },
                new Father {
                    Adresse = "TestAdresse", FirstName = "Vater1Vorname", Name = "Vater1Nachname",
                              Tel = "0123456789", Profession = "Arzt"
                }
            };
             var mothers = new List<Mother>
            {
                 new Mother {
                    MaidenName = "Mother2", Adresse = "TestAdresse", FirstName = "Mutter2Vorname", Name = "Mutter2Nachname",
                              Tel = "0123456789", Profession = "Erzieherin"},
                  new Mother
                  {
                      MaidenName = "Mother1",
                      Adresse = "TestAdresse",
                      FirstName = "Mutter1Vorname",
                      Name = "Mutter1Nachname",
                      Tel = "0123456789",
                      Profession = "Hasufrau"
                  }
            };
            
          

            var pregnancys = new Pregnancy[]
            {
                new Pregnancy { TypPregnancy = TypPregnancy.Aterm, Day = 1, TypPosition = TypPosition.Siège, Week = 22 }

            };

            foreach (Pregnancy pregnancy in pregnancys) {
                context.Pregnanicies.Add(pregnancy);
            }

            context.SaveChanges();

            List<Parent> parents1 = new List<Parent>()
            {
                fathers.FirstOrDefault(),
                mothers.FirstOrDefault()
            };
            List<Parent> parents2 = new List<Parent>()
            {
                fathers.Last(),
                mothers.Last()
            };
            var patients = new Patient[]
            {
                new Patient { Name = "Patient1Nachname",   FirstName = "Patient1Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"), 
                  //  Father = parents1,
                    Pregnancy = pregnancys.FirstOrDefault(row => row.TypPregnancy == TypPregnancy.Aterm)
                },
                
                //new Patient { Name = "TestNachname",   FirstName = "Julieta",
                //    DateOfBirth = DateTime.Parse("2010-09-01"), Fraternity = 1 },
               new Patient { Name = "Patient2Nachname",   FirstName = "Patient2Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"),
                  //  ParentBaseList = parents2.ToList(),
               },
               new Patient { Name = "Patient3Nachname",   FirstName = "Patient3Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"),
                   //  ParentBaseList = parents1.ToList(),
               },
               new Patient { Name = "Patient4Nachname",   FirstName = "Patient4Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"),
                  //  ParentBaseList = parents1.ToList(),
               },
               new Patient { Name = "Patient5Nachname",   FirstName = "Patient5Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"),
                  //  ParentBaseList = parents2.ToList(),
               },
               new Patient { Name = "Patient6Nachname",   FirstName = "Patient6Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"),
                  //  ParentBaseList = parents1.ToList(),
               },
               new Patient { Name = "Patient7Nachname",   FirstName = "Patient7Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"),
                //   ParentBaseList = parents1.ToList(),
               },new Patient { Name = "Patient8Nachname",   FirstName = "Patient8Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"),
                 //    ParentBaseList = parents1.ToList(),
               },
               new Patient { Name = "Patient9Nachname",   FirstName = "Patient9Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"),
                 //    ParentBaseList = parents1.ToList(),
               },new Patient { Name = "Patient10Nachname",   FirstName = "Patient10Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"),
                  //  ParentBaseList = parents1.ToList(),
               },
               new Patient { Name = "Patient11Nachname",   FirstName = "Patient11Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"),
                  //   ParentBaseList = parents1.ToList(),
               },



            };

            foreach (Patient patient in patients)
            {
                context.Patients.Add(patient);
            }
            context.SaveChanges();

            //foreach (Mother mother in mothers)
            //{
            //    context.Parents.Add(mother);
            //}
            //context.SaveChanges();
            //foreach (Father father in fathers)
            //{
            //    context.Parents.Add(father);
            //}
            //context.SaveChanges();
        }
    }
}
