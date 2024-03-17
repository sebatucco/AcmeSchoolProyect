using AcmeSchoolProyect.Core.Entites.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Core.Entites
{
    public class RegistrationCourse:Entity
    {
        public Guid PymentCourseId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime RegistrationDate { get; set; }
      
    }
}
