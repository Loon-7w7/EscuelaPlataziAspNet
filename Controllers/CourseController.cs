using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscuelaPlatazi.Models;

namespace EscuelaPlatazi.Controllers
{
    public class CourseController : Controller
    {
        [Route("Course/Index/")]
        [Route("Course/Index/{StudentId}")]
        public IActionResult Index(string CourseId)
        {
            if (!string.IsNullOrWhiteSpace(CourseId))
            {
                var ObjectCourse = from Cour in _Context.Courses
                                    where Cour.Id == CourseId
                                    select Cour;
                return View("Index", ObjectCourse.SingleOrDefault());
            }
            else
            {
                return View("MultiCourse", _Context.Courses);

            }

        }
        public IActionResult MultiCourse()
        {
            return View("MultiCourse", _Context.Courses);
        }

        private SchoolContext _Context;
        public CourseController(SchoolContext Context)
        {
            _Context = Context;
        }
      
    }
}
