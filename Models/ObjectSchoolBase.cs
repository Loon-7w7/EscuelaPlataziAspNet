using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaPlatazi.Models
{
    public abstract class ObjectSchoolBase
    {
        public string Id { get; set; }
        public String Name { get; set; }

        public ObjectSchoolBase()
        {
            
        }

        public override string ToString()
        {
            return $"{Name} {Id}";
        }
    }
}
