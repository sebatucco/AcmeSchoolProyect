using AcmeSchoolProyect.Core.Entites;
using AcmeSchoolProyect.Infraestructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Infraestructure.Repository
{
    public class RegistrationCourseRepositoy : RepositoryBase<RegistrationCourse>, IRegistrationCourseRepository
    {
        public RegistrationCourseRepositoy()
        {

        }

        public RegistrationCourse GetById(Guid id)
        {
           return _entities.FirstOrDefault(c => c.Id == id);
        }
    }
}
