using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using static System.Console;

namespace EscuelaPlatazi.Models
{
    public class School : ObjectSchoolBase
    {

        public int YearOfCreation { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public string AddressSchool { get; set; }
        public TypesOfSchool TypeSchool { get; set; }
        public List<Course> CourseList { get; set; }
        //public string Direcion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public School(string Name, int YearOfCreation) => (this.Name, this.YearOfCreation) = (Name, YearOfCreation);

        //public School(string Name, int YearOfCreation,
        //    TypesOfSchool TipoEscuela,
        //    string Country = "",
        //    string tonw = "")
        //{

        //    this.Name = Name;
        //    this.YearOfCreation = YearOfCreation;
        //    this.Country = Country;
        //    this.Town = tonw;
        //}
        public override string ToString()
        {
            return $"Nombre Escuela: {Name}, Tipo Escuela: {TypeSchool},\nPais: {Country}, Ciudad: {Town}";
        }

       
    }
}