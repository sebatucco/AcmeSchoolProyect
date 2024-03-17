using AcmeSchoolProyect.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Infraestructure.IRepository
{
    public interface IPaymentCourseRepository : IRepositoryBase<PaymentCourse>
    {
        PaymentCourse GetById(Guid id);
    }
}
