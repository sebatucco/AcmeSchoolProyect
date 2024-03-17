using AcmeSchoolProyect.Core.Entites.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Core.Entites
{
    public class PaymentCourse:IEntity
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public bool AmountPaid { get; set; } = false;
        public DateTime PaymentDate { get; set; }
        
    }
}
