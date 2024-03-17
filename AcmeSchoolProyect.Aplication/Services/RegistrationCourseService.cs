using AcmeSchoolProyect.Aplication.DTOs;
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
    public class RegistrationCourseService : IRegistrationCourseService
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IPaymentCourseService _paymentCourseService;
        private readonly IRegistrationCourseRepository _registrarionCourseRepository;

        public RegistrationCourseService(IStudentService studentService, ICourseService courseService, IRegistrationCourseRepository registrarionCourseRepository, IPaymentCourseService paymentCourseService)
        {
            _studentService = studentService;
            _courseService = courseService;
            _paymentCourseService = paymentCourseService;
            _registrarionCourseRepository = registrarionCourseRepository;
        }

        public IEnumerable<RegistrationCourse> GetAllRegisterCourses()
        {
            try
            {
                return _registrarionCourseRepository.GetAll();
            }
            catch (Exception e)
            {

                throw new Exception($"Error GetAllRegisterCourses: {e.Message}");
            }

        }

        public RegistrationCourse GetByIdRegisterCourse(Guid id)
        {
            try
            {
                return _registrarionCourseRepository.GetById(id);
            }
            catch (Exception e)
            {

                throw new Exception($"Error GetByIdRegisterCourse: {e.Message}");
            }

        }

        public Guid RegisterCourse(Guid studentId)
        {

            try
            {
                var student = _studentService.GetByIdStudent(studentId);
                var paymentCourse = _paymentCourseService.GetAllPaymentCourses().Where(x => x.StudentId == student.Id && x.Paid == true).FirstOrDefault();
                var course = _courseService.GetByIdCourse(paymentCourse.CourseId);

                if (student == null)
                    throw new Exception("Alumno no existe");
                if (course == null)
                    throw new Exception("Curso no existe");
                if (paymentCourse == null)
                    throw new Exception("No puede realizar la inscripcion");

                var registrationCourse = new RegistrationCourse { PymentCourseId = paymentCourse.Id, RegistrationDate = DateTime.Now };
                return _registrarionCourseRepository.Add(registrationCourse);
            }
            catch (Exception e)
            {

                throw new Exception($"Error RegisterCourse: {e.Message}");
            }

        }

        public void RemoveRegisterCourse(RegistrationCourse registrationCourse)
        {
            try
            {
                _registrarionCourseRepository.Remove(registrationCourse);
            }
            catch (Exception e)
            {

                throw new Exception($"Error RemoveRegisterCourse: {e.Message}");
            }

        }

        public List<StudentCourseDTO> GetStudentCoursesByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                if (endDate < startDate)
                    throw new Exception("Error al ingresar fecha");

                List<StudentCourseDTO> listStudentCoursesDTO = new List<StudentCourseDTO>();
                var students = _studentService.GetAllStudents();

                var courses = _courseService.GetAllCourses();
                var paymentCourses = _paymentCourseService.GetAllPaymentCourses();

                var registrationCourses = _registrarionCourseRepository.GetAll().Where(x => x.RegistrationDate >= startDate && x.RegistrationDate <= endDate);

                var studentCourses = paymentCourses.Join(registrationCourses, x => x.Id, y => y.PymentCourseId, (x, y) => new { IdStuden = x.StudentId, IdCourse = x.CourseId });

                var nameStudentCourses = studentCourses.Join(students, studentCourse => studentCourse.IdStuden, student => student.Id, (studentCourse, student) => new { studentCourse, student }).
                                          Join(courses, x => x.studentCourse.IdCourse, course => course.Id, (x, course) => new { StudentName = x.student.Name, CourseName = course.Name }).ToList();
                foreach (var item in nameStudentCourses)
                {
                    StudentCourseDTO studentCourseDTO = new StudentCourseDTO();
                    studentCourseDTO.StudentName = item.StudentName;
                    studentCourseDTO.CourseName = item.CourseName;
                    listStudentCoursesDTO.Add(studentCourseDTO);

                }
                return listStudentCoursesDTO;
            }
            catch (Exception e)
            {

                throw new Exception($"Error GetStudentCoursesByDate: {e.Message}");
            }

        }
    }
}
