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
        private readonly IPaymentCourseRepository _paymentCourseRepository;
        public PaymentCourseService(IStudentService studentService, IPaymentCourseRepository paymentCourseRepository)
        {
            _studentService = studentService;
            _paymentCourseRepository = paymentCourseRepository;
        }

        public IEnumerable<PaymentCourse> GetAllPaymentCourses()
        {
            return _paymentCourseRepository.GetAll();
        }

        public PaymentCourse GetByIdPaymentCourse(Guid id)
        {
            return _paymentCourseRepository.GetById(id);
        }


        public Guid RegisterPaymentCourse(Guid studentId)
        {
            var student = _studentService.GetByIdStudent(studentId);
            if (student == null)
                throw new InvalidOperationException("Alumno no encontrado");

            var payment = new PaymentCourse { StudentId = studentId, AmountPaid = true, PaymentDate = DateTime.Now };
            return _paymentCourseRepository.Add(payment);

        }

        public void RemovePaymentCourse(PaymentCourse paymentCourse)
        {
            _paymentCourseRepository.Remove(paymentCourse);
        }

    }
}
