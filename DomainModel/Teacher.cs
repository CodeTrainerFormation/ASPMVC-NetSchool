using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Teacher : Person
    {
        public string Discipline { get; set; }
        public DateTime HiringDate { get; set; }

        public virtual Classroom Classroom { get; set; }
    }
}
