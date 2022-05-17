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
        [Route("SubjesctF/Index/")]
        [Route("SubjesctF/Index/{SubjectsId}")]
        public IActionResult Index(string SubjectsId)
        {
            if (!string.IsNullOrWhiteSpace(SubjectsId))
            {
                var ObjectSubject = from subjec in _Context.SubjectCS
                                    where subjec.Id == SubjectsId
                                    select subjec;
                return View("Index", ObjectSubject.SingleOrDefault());
            }
            else { return View("MultiSubjesct", _Context.SubjectCS); }
            
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
