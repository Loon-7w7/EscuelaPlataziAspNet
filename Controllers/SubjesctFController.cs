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
            var ObejectSubjesct = new SubjectC { Id = Guid.NewGuid().ToString(), Name = "Math" };

            return View("Index", ObejectSubjesct);
        }
        public IActionResult MultiSubjesct()
        {
            var ListSubjesct = new List<SubjectC>() { 
                new SubjectC { Id = Guid.NewGuid().ToString(), Name = "Math" },
                new SubjectC { Id = Guid.NewGuid().ToString(), Name = "Physical Education" },
                new SubjectC { Id = Guid.NewGuid().ToString(), Name = "Castilian" },
                new SubjectC { Id = Guid.NewGuid().ToString(), Name = "Natural Sciences" }
            };
        

            return View("MultiSubjesct", ListSubjesct);
        }
    }
}
