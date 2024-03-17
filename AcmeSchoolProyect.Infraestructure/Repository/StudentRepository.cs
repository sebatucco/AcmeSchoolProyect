using AcmeSchoolProyect.Core.Entites;
using AcmeSchoolProyect.Infraestructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Infraestructure.Repository
{
    public class StudentRepository : RepositoryBase<Student>,IStudentRepository
    {
        public StudentRepository()
        {
                
        }

        public Student GetById(Guid id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }

    }
}
