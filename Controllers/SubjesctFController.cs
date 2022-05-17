using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscuelaPlatazi.Models;

namespace EscuelaPlatazi.Controllers
{
    public class SubjesctFController : Controller
    {
        public IActionResult Index()
        {


            return View("Index", _Context.SubjectCS.FirstOrDefault());
        }
        public IActionResult MultiSubjesct()
        {
          
        

            return View("MultiSubjesct", _Context.SubjectCS);
        }


        private SchoolContext _Context;
        public SubjesctFController(SchoolContext Context)
        {
            _Context = Context;
        }
    }
}
