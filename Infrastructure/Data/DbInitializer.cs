using System;
using System.Linq;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Data
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
            var parents = new Parent[]
            {
                new Mother {
                    MaidenName = "Mother1", Adresse = "TestAdresse", FirstName = "Mutter1Vorname", Name = "Mutter1Nachname",
                              Tel = 0123456789, Profession = "Hasufrau"},
                new Father {
                    Adresse = "TestAdresse", FirstName = "Vater1Vorname", Name = "Vater1Nachname",
                              Tel = 0123456789, Profession = "Arzt"
                },
                 new Mother {
                    MaidenName = "Mother2", Adresse = "TestAdresse", FirstName = "Mutter2Vorname", Name = "Mutter2Nachname",
                              Tel = 0123456789, Profession = "Erzieherin"},
                 new Father {
                    Adresse = "TestAdresse", FirstName = "Vater2Vorname", Name = "Vater2Nachname",
                              Tel = 0123456789, Profession = "Informatiker"
                },
            };
            foreach (Parent parent in parents)
            {
                context.Parents.Add(parent);
            }
            context.SaveChanges();
            var patients = new Patient[]
            {
                new Patient { Name = "Patient1Nachname",   FirstName = "Patient1Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"), Fraternity = 1,
                    Mother = parents.FirstOrDefault(row => row.FirstName == "Mutter1Vorname") as Mother,
                    Father = parents.FirstOrDefault(row => row.FirstName == "Vater1Vorname") as Father,
                },
                //new Patient { Name = "TestNachname",   FirstName = "Julieta",
                //    DateOfBirth = DateTime.Parse("2010-09-01"), Fraternity = 1 },
               new Patient { Name = "Patient2Nachname",   FirstName = "Patient2Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"), Fraternity = 2,
                    Mother = parents.FirstOrDefault(row => row.FirstName == "Mutter2Vorname") as Mother,
                    Father = parents.FirstOrDefault(row => row.FirstName == "Vater2Vorname") as Father
               },
               new Patient { Name = "Patient3Nachname",   FirstName = "Patient3Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"), Fraternity = 2,
                    Mother = parents.FirstOrDefault(row => row.FirstName == "Mutter2Vorname") as Mother,
                    Father = parents.FirstOrDefault(row => row.FirstName == "Vater2Vorname") as Father
               },
               new Patient { Name = "Patient4Nachname",   FirstName = "Patient4Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"), Fraternity = 2,
                    Mother = parents.FirstOrDefault(row => row.FirstName == "Mutter2Vorname") as Mother,
                    Father = parents.FirstOrDefault(row => row.FirstName == "Vater2Vorname") as Father
               },
               new Patient { Name = "Patient5Nachname",   FirstName = "Patient5Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"), Fraternity = 2,
                    Mother = parents.FirstOrDefault(row => row.FirstName == "Mutter2Vorname") as Mother,
                    Father = parents.FirstOrDefault(row => row.FirstName == "Vater2Vorname") as Father
               },
               new Patient { Name = "Patient6Nachname",   FirstName = "Patient6Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"), Fraternity = 2,
                    Mother = parents.FirstOrDefault(row => row.FirstName == "Mutter2Vorname") as Mother,
                    Father = parents.FirstOrDefault(row => row.FirstName == "Vater2Vorname") as Father
               },
               new Patient { Name = "Patient7Nachname",   FirstName = "Patient7Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"), Fraternity = 2,
                    Mother = parents.FirstOrDefault(row => row.FirstName == "Mutter2Vorname") as Mother,
                    Father = parents.FirstOrDefault(row => row.FirstName == "Vater2Vorname") as Father
               },new Patient { Name = "Patient8Nachname",   FirstName = "Patient8Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"), Fraternity = 2,
                    Mother = parents.FirstOrDefault(row => row.FirstName == "Mutter2Vorname") as Mother,
                    Father = parents.FirstOrDefault(row => row.FirstName == "Vater2Vorname") as Father
               },
               new Patient { Name = "Patient9Nachname",   FirstName = "Patient9Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"), Fraternity = 2,
                    Mother = parents.FirstOrDefault(row => row.FirstName == "Mutter2Vorname") as Mother,
                    Father = parents.FirstOrDefault(row => row.FirstName == "Vater2Vorname") as Father
               },new Patient { Name = "Patient10Nachname",   FirstName = "Patient10Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"), Fraternity = 2,
                    Mother = parents.FirstOrDefault(row => row.FirstName == "Mutter2Vorname") as Mother,
                    Father = parents.FirstOrDefault(row => row.FirstName == "Vater2Vorname") as Father
               },
               new Patient { Name = "Patient11Nachname",   FirstName = "Patient11Vorname",
                    DateOfBirth = DateTime.Parse("2010-09-01"), Fraternity = 2,
                    Mother = parents.FirstOrDefault(row => row.FirstName == "Mutter2Vorname") as Mother,
                    Father = parents.FirstOrDefault(row => row.FirstName == "Vater2Vorname") as Father
               },



            };

            foreach (Patient patient in patients)
            {
                context.Patients.Add(patient);
            }
            context.SaveChanges();
        }
    }
}
