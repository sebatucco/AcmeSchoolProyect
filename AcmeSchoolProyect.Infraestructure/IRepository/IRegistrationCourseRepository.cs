using AcmeSchoolProyect.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Infraestructure.IRepository
{
    public interface IRegistrationCourseRepository : IRepositoryBase<RegistrationCourse>
    {
        RegistrationCourse GetById(Guid id);
    }
}
