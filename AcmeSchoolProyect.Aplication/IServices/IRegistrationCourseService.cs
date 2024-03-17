using AcmeSchoolProyect.Aplication.DTOs;
using AcmeSchoolProyect.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Aplication.IServices
{
    public interface IRegistrationCourseService
    {
        Guid RegisterCourse(Guid studentId, Guid courseId);
        IEnumerable<RegistrationCourse> GetAllRegisterCourses();
        void RemoveRegisterCourse(RegistrationCourse course);
        RegistrationCourse GetByIdRegisterCourse(Guid id);
        List<StudentCourseDTO> GetStudentCoursesByDate(DateTime startDate, DateTime endTime);
    }
}
