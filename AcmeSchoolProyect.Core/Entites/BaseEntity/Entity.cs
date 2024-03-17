using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Core.Entites.BaseEntity
{
    public class Entity:IEntity
    {
        public Guid Id { get; set; }
    }
}
