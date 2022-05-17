using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscuelaPlatazi.Models;
using Microsoft.EntityFrameworkCore;

namespace EscuelaPlatazi.Controllers
{
    public class EscuelaController : Controller
    {
        private SchoolContext _Context;
        public IActionResult Index() 
        {
            var objSchool = _Context.Schools.FirstOrDefault();
            return View(objSchool);
        }
        public EscuelaController(SchoolContext Context) 
        {
            _Context = Context;
        }
    }
}
