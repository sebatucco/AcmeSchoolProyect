using AcmeSchoolProyect.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Aplication.IServices
{
    public interface IStudentService
    {
        Guid RegisterStudent(string name, int age);
        IEnumerable<Student> GetAllStudents();
        void RemoveStudent(Student student);
       Student GetByIdStudent(Guid id);
    }
}
