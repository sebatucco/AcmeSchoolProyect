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
    public class PaymentCourseService : IPaymentCourseService
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IPaymentCourseRepository _paymentCourseRepository;
        public PaymentCourseService(IStudentService studentService, IPaymentCourseRepository paymentCourseRepository, ICourseService courseService)
        {
            _studentService = studentService;
            _paymentCourseRepository = paymentCourseRepository;
            _courseService = courseService;
        }

        public IEnumerable<PaymentCourse> GetAllPaymentCourses()
        {
            return _paymentCourseRepository.GetAll();
        }

        public PaymentCourse GetByIdPaymentCourse(Guid id)
        {
            return _paymentCourseRepository.GetById(id);
        }


        public Guid RegisterPaymentCourse(Guid studentId, Guid courseId, int pay)
        {
            var student = _studentService.GetByIdStudent(studentId);
            var course = _courseService.GetByIdCourse(courseId);

            if (student == null)
                throw new InvalidOperationException("Alumno no encontrado");
            if (course == null)
                throw new InvalidOperationException("Curso no existe");
            if(!course.CourseCost.Equals(pay))
                throw new InvalidOperationException("No coincide con valor del curso");

            var payment = new PaymentCourse { StudentId = studentId, CourseId = courseId, Pay = pay, Paid = true, PaymentDate = DateTime.Now };
            return _paymentCourseRepository.Add(payment);

        }

        public void RemovePaymentCourse(PaymentCourse paymentCourse)
        {
            _paymentCourseRepository.Remove(paymentCourse);
        }

    }
}
