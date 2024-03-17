using AcmeSchoolProyect.Core.Entites.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Core.Entites
{
    public class Course:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
       
    }
}

