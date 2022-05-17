using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscuelaPlatazi.Models;

namespace EscuelaPlatazi.Controllers
{
    public class EscuelaController : Controller
    {
        private SchoolContext _Context;
        public IActionResult Index() 
        {
            //var objSchool = new School();
            //objSchool.YearOfCreation = 2005;
            //objSchool.Id = Guid.NewGuid().ToString();
            //objSchool.Name = "Platzi School";
            //objSchool.Country = "Colombia";
            //objSchool.Town = "Bogota";
            //objSchool.TypeSchool = TypesOfSchool.Highschool;
            //objSchool.AddressSchool = "Avd Simpre Viva";
            var objSchool = _Context.Schools.FirstOrDefault();
            return View(objSchool);
        }
        public EscuelaController(SchoolContext Context) 
        {
            _Context = Context;
        }
    }
}
