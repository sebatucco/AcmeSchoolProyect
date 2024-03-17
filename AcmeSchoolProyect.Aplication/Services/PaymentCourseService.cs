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
            try
            {
                return _paymentCourseRepository.GetAll();
            }
            catch (Exception e)
            {

                throw new Exception($"Error GetAllPaymentCourses: {e.Message}");
            }

        }

        public PaymentCourse GetByIdPaymentCourse(Guid id)
        {
            try
            {
                return _paymentCourseRepository.GetById(id);
            }
            catch (Exception e)
            {

                throw new Exception($"Error GetByIdPaymentCourse: {e.Message}");
            }

        }


        public Guid RegisterPaymentCourse(Guid studentId, Guid courseId, int pay)
        {
            try
            {
                var student = _studentService.GetByIdStudent(studentId);
                var course = _courseService.GetByIdCourse(courseId);

                if (student == null)
                    throw new Exception("Alumno no encontrado");
                if (course == null)
                    throw new Exception("Curso no existe");
                if (!course.CourseCost.Equals(pay))
                    throw new Exception("No coincide con valor del curso");

                var payment = new PaymentCourse { StudentId = studentId, CourseId = courseId, Pay = pay, Paid = true, PaymentDate = DateTime.Now };
                return _paymentCourseRepository.Add(payment);

            }
            catch (Exception e)
            {

                throw new Exception($"Error RegisterPaymentCourse: {e.Message}");
            }


        }

        public void RemovePaymentCourse(PaymentCourse paymentCourse)
        {
            try
            {
                _paymentCourseRepository.Remove(paymentCourse);
            }
            catch (Exception e)
            {

                throw new Exception($"Error RemovePaymentCourse: {e.Message}");
            }

        }

    }
}
