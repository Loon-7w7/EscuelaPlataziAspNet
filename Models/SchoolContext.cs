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
            //Cargar cursos de la Escuela
            var Objectcourses = uploadCourses(objSchool);
            //x cada curso cargar asignaturas
            var objectSubject = LoadSubjects(Objectcourses);
            //x cada curso cargar alunmos
            var ObjetStudent = LoadStudent(Objectcourses);

            modelBuilder.Entity<School>().HasData(objSchool);
            modelBuilder.Entity<Course>().HasData(Objectcourses.ToArray());
            modelBuilder.Entity<SubjectC>().HasData(objectSubject.ToArray());
            modelBuilder.Entity<Student>().HasData(ObjetStudent.ToArray());

        }

        private static List<SubjectC> LoadSubjects(List<Course> courses)
        {
            var SubjectsList = new List<SubjectC>();
            foreach (var itemCurso in courses)
            {
                var TmpListe = new List<SubjectC>()
                {
                new SubjectC { Id = Guid.NewGuid().ToString(), Name = "Math" , CourseId = itemCurso.Id },
                new SubjectC { Id = Guid.NewGuid().ToString(), Name = "Physical Education", CourseId = itemCurso.Id},
                new SubjectC { Id = Guid.NewGuid().ToString(), Name = "Castilian", CourseId = itemCurso.Id},
                new SubjectC { Id = Guid.NewGuid().ToString(), Name = "Natural Sciences", CourseId = itemCurso.Id}
                };

                SubjectsList.AddRange(TmpListe);
                //itemCurso.ListOfSubjects = TmpListe;
            }
            return SubjectsList;
        }

        private List<Student> GenerateRandomStudents(int Amount , Course ObjectCourse)
        {

            string[] PrimerNombre = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] ApeliidoPaterno = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] SegundoNombre = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var ListadeAlunnos = from Nombre1 in PrimerNombre
                                 from Nombre2 in SegundoNombre
                                 from Apellido in ApeliidoPaterno
                                 select new Student
                                 {
                                     CourseId = ObjectCourse.Id,
                                     Name = $"{Nombre1} {Nombre2} {Apellido}",
                                     Id = Guid.NewGuid().ToString()
                                 };
            return ListadeAlunnos.OrderBy((Alum) => Alum.Id).Take(Amount).ToList();
        }
        private static List<Course> uploadCourses(School objSchool)
        {
            return  new List<Course>()
            {
                new Course(){Id=Guid.NewGuid().ToString(),SchoolId = objSchool.Id ,Name ="101", TypeOfDay = TypesDay.Morning },
                new Course(){Id=Guid.NewGuid().ToString(),SchoolId = objSchool.Id ,Name ="201", TypeOfDay = TypesDay.Morning },
                new Course(){Id=Guid.NewGuid().ToString(),SchoolId = objSchool.Id ,Name ="301", TypeOfDay = TypesDay.Morning },
                new Course(){Id=Guid.NewGuid().ToString(),SchoolId = objSchool.Id ,Name ="401", TypeOfDay = TypesDay.Afternoon },
                new Course(){Id=Guid.NewGuid().ToString(),SchoolId = objSchool.Id ,Name ="501", TypeOfDay = TypesDay.Afternoon },

            };
            
        }

        private List<Student> LoadStudent(List<Course> CourseList) 
        {
            var StudentList = new List<Student>();
            Random RND = new Random();
            foreach (var itemCourse in CourseList)
            {
                int randomamount = RND.Next(5, 20);
                var tempList = GenerateRandomStudents(randomamount, itemCourse);
                StudentList.AddRange(tempList);
            }
            return StudentList;
        }
    }
}
