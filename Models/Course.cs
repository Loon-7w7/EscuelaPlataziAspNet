using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaPlatazi.Models
{
    public class Course : ObjectSchoolBase
    {
        [Required]
        public override string Name { get; set; }
        [Required]
        [Display(Name = "Day Type", ShortName = "Type")]
        [EnumDataType(typeof(TypesDay))]
        public TypesDay TypeOfDay { get; set; }

        public List<SubjectC> ListOfSubjects { get; set; }
        public List<Student> StudentList { get; set; }
        public string Direcion { get; set; }
        [Display(Name = "School", Prompt = "Provide a Name")]
        public string SchoolId { get; set; }
        public School school { get; set; }

    }
}
