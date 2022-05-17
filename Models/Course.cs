using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaPlatazi.Models
{
    public class Course : ObjectSchoolBase
    {

        public TypesDay TypeOfDay { get; set; }

        public List<SubjectC> ListOfSubjects { get; set; }
        public List<Student> StudentList { get; set; }
        public string Direcion { get; set; }

       
    }
}
