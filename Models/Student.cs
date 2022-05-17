using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaPlatazi.Models
{
    public class Student : ObjectSchoolBase
    {

        public List<Evaluations> ListEvaluations { get; set; }
        public string CourseId { get; set; }
        public Course course { get; set; }
    }
}

