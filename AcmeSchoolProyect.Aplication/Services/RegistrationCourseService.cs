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
            return _registrarionCourseRepository.GetAll();
        }

        public RegistrationCourse GetByIdRegisterCourse(Guid id)
        {
            return _registrarionCourseRepository.GetById(id);
        }

        public Guid RegisterCourse(Guid studentId, Guid courseId)
        {
            var student = _studentService.GetByIdStudent(studentId);
            var course = _courseService.GetByIdCourse(courseId);
            var paymentCourse = _paymentCourseService.GetAllPaymentCourses().Where(x => x.StudentId == student.Id).FirstOrDefault();

            if (student == null)
                throw new InvalidOperationException("Alumno no existe");
            if (course == null)
                throw new InvalidOperationException("Alumno no existe");
            if (paymentCourse == null)
                throw new InvalidOperationException("Alumno sin pago");

            var registrationCourse = new RegistrationCourse { PymentCourseId = paymentCourse.Id, CourseId = course.Id, RegistrationDate = DateTime.Now };
            return _registrarionCourseRepository.Add(registrationCourse);
        }

        public void RemoveRegisterCourse(RegistrationCourse course)
        {
            _registrarionCourseRepository.Remove(course);
        }

        public List<StudentCourseDTO> GetStudentCoursesByDate(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                throw new InvalidOperationException("Error al ingresar fecha");
            List<StudentCourseDTO> listStudentCoursesDTO = new List<StudentCourseDTO>();
            var students = _studentService.GetAllStudents();

            var courses = _courseService.GetAllCourses();
            var paymentCourses = _paymentCourseService.GetAllPaymentCourses();

            var registrationCourses = _registrarionCourseRepository.GetAll().Where(x => x.RegistrationDate >= startDate && x.RegistrationDate <= endDate);

            var studentCourses = paymentCourses.Join(registrationCourses, x => x.Id, y => y.PymentCourseId, (x, y) => new { IdStuden = x.StudentId, IdCourse = y.CourseId });

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
    }
}
