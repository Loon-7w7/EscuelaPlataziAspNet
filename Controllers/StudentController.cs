using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscuelaPlatazi.Models;

namespace EscuelaPlatazi.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var ObejectSTudents = new Student { UniqueId = Guid.NewGuid().ToString(), Name = "Pepe Perez" };

            return View("Index", ObejectSTudents);
        }
        public IActionResult MultiStudent()
        {
            var ListSTudents = GenerateRandomStudents();



            return View("MultiStudent", ListSTudents);
        }
        private List<Student> GenerateRandomStudents()
        {
            string[] PrimerNombre = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] ApeliidoPaterno = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] SegundoNombre = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var ListadeAlunnos = from Nombre1 in PrimerNombre
                                 from Nombre2 in SegundoNombre
                                 from Apellido in ApeliidoPaterno
                                 select new Student { Name = $"{Nombre1} {Nombre2} {Apellido}",
                                     UniqueId = Guid.NewGuid().ToString()
                                 };
            return ListadeAlunnos.OrderBy((Alum) => Alum.UniqueId).ToList();
        }
    }
}
