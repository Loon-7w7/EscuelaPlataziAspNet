using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace EscuelaPlatazi.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<SubjectC> SubjectCS { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Evaluations> EvaluationsS { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options): base (options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            var objSchool = new School();
            objSchool.YearOfCreation = 2005;
            objSchool.Id = Guid.NewGuid().ToString();
            objSchool.Name = "Platzi School";
            objSchool.Country = "Colombia";
            objSchool.Town = "Bogota";
            objSchool.TypeSchool = TypesOfSchool.Highschool;
            objSchool.AddressSchool = "Avd Simpre Viva";
            modelBuilder.Entity<School>().HasData(objSchool);

            modelBuilder.Entity<SubjectC>().HasData(
                new SubjectC { Id = Guid.NewGuid().ToString(), Name = "Math" },
                new SubjectC { Id = Guid.NewGuid().ToString(), Name = "Physical Education" },
                new SubjectC { Id = Guid.NewGuid().ToString(), Name = "Castilian" },
                new SubjectC { Id = Guid.NewGuid().ToString(), Name = "Natural Sciences" }
                );

            modelBuilder.Entity<Student>().HasData(GenerateRandomStudents().ToArray());
        }

        private List<Student> GenerateRandomStudents()
        {
            string[] PrimerNombre = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] ApeliidoPaterno = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] SegundoNombre = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var ListadeAlunnos = from Nombre1 in PrimerNombre
                                 from Nombre2 in SegundoNombre
                                 from Apellido in ApeliidoPaterno
                                 select new Student
                                 {
                                     Name = $"{Nombre1} {Nombre2} {Apellido}",
                                     Id = Guid.NewGuid().ToString()
                                 };
            return ListadeAlunnos.OrderBy((Alum) => Alum.Id).ToList();
        }
    }
}
