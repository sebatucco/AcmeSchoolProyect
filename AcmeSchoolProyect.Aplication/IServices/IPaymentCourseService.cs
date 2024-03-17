using AcmeSchoolProyect.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Aplication.IServices
{
    public interface IPaymentCourseService
    {
        Guid RegisterPaymentCourse(Guid studentId);
        IEnumerable<PaymentCourse> GetAllPaymentCourses();
        void RemovePaymentCourse(PaymentCourse paymentCourse);
        PaymentCourse GetByIdPaymentCourse(Guid id);
    }
}
