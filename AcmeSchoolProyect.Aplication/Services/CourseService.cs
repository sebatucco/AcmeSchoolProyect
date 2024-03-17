using AcmeSchoolProyect.Aplication.IServices;
using AcmeSchoolProyect.Core.Entites;
using AcmeSchoolProyect.Infraestructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Aplication.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;  
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.GetAll();
        }

        public Course GetByIdCourse(Guid id)
        {
            return _courseRepository.GetById(id);
        }

        public Guid RegisterCourse(string name, int courseCost, DateTime startDateCourse, DateTime endDateCourse)
        {
            if (endDateCourse < startDateCourse)
                throw new InvalidOperationException("Error en fechas de curso");

            var course = new Course { Name = name, CourseCost = courseCost, StartDateCourse = startDateCourse, EndDateCourse= endDateCourse};
            return _courseRepository.Add(course);

        }

        public void RemoveCourse(Course course)
        {
            _courseRepository.Remove(course);
        }
    }
}
