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
            try
            {
                return _courseRepository.GetAll();
            }
            catch (Exception e)
            {

                throw new Exception($"Error GetAllCourses: {e.Message}");
            }

        }

        public Course GetByIdCourse(Guid id)
        {
            try
            {
                return _courseRepository.GetById(id);
            }
            catch (Exception e)
            {

                throw new Exception($"Error GetByIdCourse: {e.Message}");
            }

        }

        public Guid RegisterCourse(string name, int courseCost, DateTime startDateCourse, DateTime endDateCourse)
        {
            try
            {
                if (endDateCourse < startDateCourse)
                    throw new Exception("Error en fechas de curso");

                var course = new Course { Name = name, CourseCost = courseCost, StartDateCourse = startDateCourse, EndDateCourse = endDateCourse };
                return _courseRepository.Add(course);
            }
            catch (Exception e)
            {

                throw new Exception($"Error RegisterCourse: {e.Message}");
            }


        }

        public void RemoveCourse(Course course)
        {
            try
            {
                _courseRepository.Remove(course);
            }
            catch (Exception e)
            {

                throw new Exception($"Error RemoveCourse: {e.Message}");
            }

        }
    }
}
