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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetByIdStudent(Guid id)
        {
            return _studentRepository.GetById(id);
        }

        public Guid RegisterStudent(string name, int age)
        {
            if (age < 18)
                throw new InvalidOperationException("Solo mayores de edad pueden registrar");
            var student = new Student { Name = name, Age = age };
            return _studentRepository.Add(student);
           
        }

        public void RemoveStudent(Student student)
        {
            _studentRepository.Remove(student);
        }
    }
}
