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
        [Route("Student/Index/")]
        [Route("Student/Index/{StudentId}")]
        public IActionResult Index(string StudentId)
        {
            if (!string.IsNullOrWhiteSpace(StudentId))
            {
                var ObjectStudent = from Stude in _Context.Students
                                    where Stude.Id == StudentId
                                    select Stude;
                return View("Index", ObjectStudent.SingleOrDefault());
            }
            else
            {
                return View("MultiStudent", _Context.Students);

            }

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
