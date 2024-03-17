using AcmeSchoolProyect.Core.Entites.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Core.Entites
{
    public class PaymentCourse:Entity
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public int Pay { get; set; }
        public bool Paid { get; set; } = false;
        public DateTime PaymentDate { get; set; }
        
    }
}
