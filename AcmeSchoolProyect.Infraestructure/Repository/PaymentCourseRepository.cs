using AcmeSchoolProyect.Core.Entites;
using AcmeSchoolProyect.Infraestructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Infraestructure.Repository
{
    public class PaymentCourseRepository : RepositoryBase<PaymentCourse>, IPaymentCourseRepository
    {
        public PaymentCourseRepository()
        {

        }

        public PaymentCourse GetById(Guid id)
        {
           return _entities.FirstOrDefault(c => c.Id == id);
        }
    }
}
