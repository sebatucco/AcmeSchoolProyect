using AcmeSchoolProyect.Core.Entites;
using AcmeSchoolProyect.Infraestructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Infraestructure.Repository
{
    public class CourseRepository : RepositoryBase<Course>,ICourseRepository
    {
        public CourseRepository()
        {
                
        }

        public Course GetById(Guid id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }

    }
}
