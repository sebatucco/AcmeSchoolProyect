using AcmeSchoolProyect.Core.Entites.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Core.Entites
{
    public class Course:Entity
    {
        public string Name { get; set; }
        public int CourseCost { get; set; }
        public DateTime StartDateCourse { get; set; }
        public DateTime EndDateCourse { get; set; }

       
    }
}

