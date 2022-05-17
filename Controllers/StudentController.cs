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
            var ObejectSTudents = new Student { Id = Guid.NewGuid().ToString(), Name = "Pepe Perez" };

            return View("Index",_Context.Students.FirstOrDefault() );
        }
        public IActionResult MultiStudent()
        {
            return View("MultiStudent", _Context.Students);
        }

        private SchoolContext _Context;
        public StudentController(SchoolContext Context)
        {
            _Context = Context;
        }
      
    }
}
