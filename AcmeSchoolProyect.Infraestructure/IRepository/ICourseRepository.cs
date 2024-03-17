using AcmeSchoolProyect.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Infraestructure.IRepository
{
    public interface ICourseRepository: IRepositoryBase<Course>
    {
        Course GetById(Guid id);
    }
}
