using AcmeSchoolProyect.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Aplication.IServices
{
    public interface ICourseService
    {
        Guid RegisterCourse(string name);
        IEnumerable<Course> GetAllCourses();
        void RemoveCourse(Course course);
       Course GetByIdCourse(Guid id);
    }
}
