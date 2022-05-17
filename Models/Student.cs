using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaPlatazi.Models
{
    public class Student : ObjectSchoolBase
    {

        public List<Evaluations> ListEvaluations { get; set; } = new List<Evaluations>();

    }
}

