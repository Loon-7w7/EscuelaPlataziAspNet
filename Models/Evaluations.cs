using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaPlatazi.Models
{
    public class Evaluations : ObjectSchoolBase
    {

        public Student ObjectStudent { get; set; }
        public SubjectC ObjectSubject { get; set; }
        public float Calificacion { get; set; }


        public override string ToString()
        {
            return $"{Calificacion} {ObjectStudent.Name} {ObjectSubject.Name}";
        }
    }
}

