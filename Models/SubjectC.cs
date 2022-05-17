using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaPlatazi.Models
{
    public class SubjectC : ObjectSchoolBase
    {
        public string CourseId { get; set; }
        public Course course { get; set; }
    }
}
