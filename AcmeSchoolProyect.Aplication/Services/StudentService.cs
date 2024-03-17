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
            try
            {
                return _studentRepository.GetAll();
            }
            catch (Exception e)
            {

                throw new Exception($"Error GetAllStudents: {e.Message}");
            }
           
        }

        public Student GetByIdStudent(Guid id)
        {
            try
            {
                return _studentRepository.GetById(id);
            }
            catch (Exception e)
            {

                throw new Exception($"Error GetByIdStudent: {e.Message}");
            }
           
        }

        public Guid RegisterStudent(string name, int age)
        {
            try
            {
                if (age < 18)
                    throw new Exception("Solo mayores de edad pueden registrar");
                var student = new Student { Name = name, Age = age };
                return _studentRepository.Add(student);
            }
            catch (Exception e)
            {

                throw new Exception($"Error RegisterStudent: {e.Message}");
            }
           
           
        }

        public void RemoveStudent(Student student)
        {
            try
            {
                _studentRepository.Remove(student);
            }
            catch (Exception e)
            {

                throw new Exception($"Error RemoveStudent: {e.Message}");
            }
           
        }
    }
}
