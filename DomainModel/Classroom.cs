using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Classroom
    {
        //Propriétés scalaires
        public int ClassroomID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public int Floor { get; set; }

        [StringLength(20)]
        public string Corridor { get; set; }

        //Propriétés de navigation
        public virtual ICollection<Student> Students { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
