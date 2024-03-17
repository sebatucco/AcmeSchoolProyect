using AcmeSchoolProyect.Aplication.IServices;
using AcmeSchoolProyect.Aplication.Services;
using AcmeSchoolProyect.Core.Entites;
using AcmeSchoolProyect.Infraestructure.IRepository;
using AcmeSchoolProyect.Infraestructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;
using System.Xml.Linq;

namespace AcmeSchoolProyect.Tests
{
    public class UnitTestAcmeSchoolProyect
    {

        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IPaymentCourseService _paymentCourseService;
        private readonly IRegistrationCourseService _registratrionCourseService;

        public UnitTestAcmeSchoolProyect()
        {
            var servicesProvider = new ServiceCollection()
             .AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>))
             .AddScoped<IStudentRepository, StudentRepository>()
             .AddScoped<ICourseRepository, CourseRepository>()
             .AddScoped<IPaymentCourseRepository, PaymentCourseRepository>()
             .AddScoped<IRegistrationCourseRepository, RegistrationCourseRepositoy>()
             .AddScoped<IStudentService, StudentService>()
             .AddScoped<ICourseService, CourseService>()
             .AddScoped<IPaymentCourseService, PaymentCourseService>()
             .AddScoped<IRegistrationCourseService, RegistrationCourseService>()
             .BuildServiceProvider();

            _studentService = servicesProvider.GetService<IStudentService>();
            _courseService = servicesProvider.GetService<ICourseService>();
            _paymentCourseService = servicesProvider.GetService<IPaymentCourseService>();
            _registratrionCourseService = servicesProvider.GetService<IRegistrationCourseService>();
        }
        #region student
        [Fact]
        public void AddStudent()
        {
            string name = "Daniela";
            int age = 20;

            var studentId = _studentService.RegisterStudent(name, age);
            Assert.NotEqual(Guid.Empty, studentId);
        }

        [Fact]
        public void GetAllStudent()
        {
            string name = "Daniela";
            int age = 20;
            _studentService.RegisterStudent(name, age);
            name = "Emilse";
            age = 19;
            _studentService.RegisterStudent(name, age);
            var students = _studentService.GetAllStudents();
            Assert.NotNull(students);
            Assert.NotEmpty(students);
        }

        [Fact]
        public void GetStudentById()
        {
            string name = "Daniela";
            int age = 20;
            var studentId = _studentService.RegisterStudent(name, age);
            var student = _studentService.GetByIdStudent(studentId);
            Assert.Equal(studentId, student.Id);
        }

        [Fact]
        public void RemoveStudent()
        {
            string name = "Daniela";
            int age = 20;
            var studentId = _studentService.RegisterStudent(name, age);
            var student = _studentService.GetByIdStudent(studentId);
            _studentService.RemoveStudent(student);
            var students = _studentService.GetAllStudents();
            var newStudent = students.FirstOrDefault(s => s.Name == name && s.Age == age);
            Assert.Null(newStudent);
        }

        #endregion
        #region course
        [Fact]
        public void AddCourse()
        {
            string name = "Informatica";
            int courseCost = 10;
            DateTime startDateCourse = DateTime.Now;
            DateTime endDateCourse = DateTime.Now.AddMonths(3);
            var courseId = _courseService.RegisterCourse(name, courseCost, startDateCourse, endDateCourse);
            Assert.NotEqual(Guid.Empty, courseId);
        }

        [Fact]
        public void GetAllCourse()
        {
            string name = "Informatica";
            int courseCost = 10;
            DateTime startDateCourse = DateTime.Now;
            DateTime endDateCourse = DateTime.Now.AddMonths(3);
            _courseService.RegisterCourse(name, courseCost, startDateCourse, endDateCourse);

            name = "Redes";
            courseCost = 10;
            startDateCourse = DateTime.Now;
            endDateCourse = DateTime.Now.AddMonths(3);
            _courseService.RegisterCourse(name, courseCost, startDateCourse, endDateCourse);

            var courses = _courseService.GetAllCourses();
            Assert.NotNull(courses);
            Assert.NotEmpty(courses);
        }

        [Fact]
        public void GetCourseById()
        {
            string name = "Informatica";
            int courseCost = 10;
            DateTime startDateCourse = DateTime.Now;
            DateTime endDateCourse = DateTime.Now.AddMonths(3);
            var courseId = _courseService.RegisterCourse(name, courseCost, startDateCourse, endDateCourse);
            var course = _courseService.GetByIdCourse(courseId);
            Assert.Equal(courseId, course.Id);
        }

        [Fact]
        public void RemoveCourse()
        {
            string name = "Informatica";
            int courseCost = 10;
            DateTime startDateCourse = DateTime.Now;
            DateTime endDateCourse = DateTime.Now.AddMonths(3);
            var courseId = _courseService.RegisterCourse(name, courseCost, startDateCourse, endDateCourse);
            var course = _courseService.GetByIdCourse(courseId);
            _courseService.RemoveCourse(course);
            var courses = _courseService.GetAllCourses();
            var newCourse = courses.FirstOrDefault(s => s.Name == name);
            Assert.Null(newCourse);
        }
        #endregion
        #region payment course
        [Fact]
        public void AddPaymentCourse()
        {
            string name = "Daniela";
            int age = 20;
            var studentId = _studentService.RegisterStudent(name, age);

            string nameCourse = "Informatica";
            int courseCost = 10;
            DateTime startDateCourse = DateTime.Now;
            DateTime endDateCourse = DateTime.Now.AddMonths(3);
            var courseId = _courseService.RegisterCourse(nameCourse, courseCost, startDateCourse, endDateCourse);

            int pay = 10;
            var paymentCourseId = _paymentCourseService.RegisterPaymentCourse(studentId, courseId, pay);
            Assert.NotEqual(Guid.Empty, paymentCourseId);
        }

        [Fact]
        public void GetAllPaymentCourse()
        {
            string name = "Daniela";
            int age = 20;
            var studentId = _studentService.RegisterStudent(name, age);

            string nameCourse = "Informatica";
            int courseCost = 10;
            DateTime startDateCourse = DateTime.Now;
            DateTime endDateCourse = DateTime.Now.AddMonths(3);
            var courseId = _courseService.RegisterCourse(nameCourse, courseCost, startDateCourse, endDateCourse);

            int pay = 10;
            _paymentCourseService.RegisterPaymentCourse(studentId, courseId, pay);


            name = "Emilse";
            age = 19;
            studentId = _studentService.RegisterStudent(name, age);

            nameCourse = "Redes";
            courseCost = 20;
            startDateCourse = DateTime.Now;
            endDateCourse = DateTime.Now.AddMonths(3);
            courseId = _courseService.RegisterCourse(nameCourse, courseCost, startDateCourse, endDateCourse);

            pay = 20;
            _paymentCourseService.RegisterPaymentCourse(studentId, courseId, pay);

            var paymentCourses = _paymentCourseService.GetAllPaymentCourses();
            Assert.NotNull(paymentCourses);
            Assert.NotEmpty(paymentCourses);
        }

        [Fact]
        public void GetPaymentCourseById()
        {
            string name = "Daniela";
            int age = 20;
            var studentId = _studentService.RegisterStudent(name, age);

            string nameCourse = "Informatica";
            int courseCost = 10;
            DateTime startDateCourse = DateTime.Now;
            DateTime endDateCourse = DateTime.Now.AddMonths(3);
            var courseId = _courseService.RegisterCourse(nameCourse, courseCost, startDateCourse, endDateCourse);

            int pay = 10;
            var paymentCourseId = _paymentCourseService.RegisterPaymentCourse(studentId, courseId, pay);

            var paymentCourse = _paymentCourseService.GetByIdPaymentCourse(paymentCourseId);
            Assert.Equal(paymentCourseId, paymentCourse.Id);
        }

        [Fact]
        public void RemovePaymentCourse()
        {
            string name = "Daniela";
            int age = 20;
            var studentId = _studentService.RegisterStudent(name, age);

            string nameCourse = "Informatica";
            int courseCost = 10;
            DateTime startDateCourse = DateTime.Now;
            DateTime endDateCourse = DateTime.Now.AddMonths(3);
            var paymentCourseId = _courseService.RegisterCourse(nameCourse, courseCost, startDateCourse, endDateCourse);

            var paymentCourse = _paymentCourseService.GetByIdPaymentCourse(paymentCourseId);
            _paymentCourseService.RemovePaymentCourse(paymentCourse);
            var paymentCourses = _paymentCourseService.GetAllPaymentCourses();
            var newPaymentCourse = paymentCourses.FirstOrDefault(s => s.Id == paymentCourseId);
            Assert.Null(newPaymentCourse);
        }
        #endregion
        #region registration course
        [Fact]
        public void AddRegistrationCourse()
        {
            string nameStudent = "Daniela";
            int age = 20;
            var studentId = _studentService.RegisterStudent(nameStudent, age);

            string nameCourse = "Informatica";
            int courseCost = 10;
            DateTime startDateCourse = DateTime.Now;
            DateTime endDateCourse = DateTime.Now.AddMonths(3);
            var courseId = _courseService.RegisterCourse(nameCourse, courseCost, startDateCourse, endDateCourse);

            int pay = 10;
            _paymentCourseService.RegisterPaymentCourse(studentId, courseId, pay);
            var registrationCourseId = _registratrionCourseService.RegisterCourse(studentId);
            Assert.NotEqual(Guid.Empty, registrationCourseId);
        }

        [Fact]
        public void GetStudentCoursesByDate()
        {
            DateTime startDate = DateTime.Now.AddDays(-1);
            DateTime endDate = DateTime.Now.AddDays(1);

            string nameStudent = "Daniela";
            int age = 20;
            var studentId = _studentService.RegisterStudent(nameStudent, age);

            string nameCourse = "Informatica";
            int courseCost = 10;
            DateTime startDateCourse = DateTime.Now;
            DateTime endDateCourse = DateTime.Now.AddMonths(3);
            var courseId = _courseService.RegisterCourse(nameCourse, courseCost, startDateCourse, endDateCourse);

            int pay = 10;
            var paymentCourseId = _paymentCourseService.RegisterPaymentCourse(studentId, courseId, pay);
            _registratrionCourseService.RegisterCourse(studentId);

            nameStudent = "Emilse";
            age = 19;
            studentId = _studentService.RegisterStudent(nameStudent, age);

            nameCourse = "Redes";
            courseCost = 20;
            startDateCourse = DateTime.Now;
            endDateCourse = DateTime.Now.AddMonths(3);
            courseId = _courseService.RegisterCourse(nameCourse, courseCost, startDateCourse, endDateCourse);

            pay = 20;

            paymentCourseId = _paymentCourseService.RegisterPaymentCourse(studentId, courseId, pay);
            _registratrionCourseService.RegisterCourse(studentId);

            var studentCourses = _registratrionCourseService.GetStudentCoursesByDate(startDate, endDate);
            Assert.NotNull(studentCourses);
            Assert.NotEmpty(studentCourses);
        }

        [Fact]
        public void GetAllRegistrationCourse()
        {
            string nameStudent = "Daniela";
            int age = 20;
            var studentId = _studentService.RegisterStudent(nameStudent, age);

            string nameCourse = "Informatica";
            int courseCost = 10;
            DateTime startDateCourse = DateTime.Now;
            DateTime endDateCourse = DateTime.Now.AddMonths(3);
            var courseId = _courseService.RegisterCourse(nameCourse, courseCost, startDateCourse, endDateCourse);

            int pay = 10;
            var paymentCourseId = _paymentCourseService.RegisterPaymentCourse(studentId, courseId, pay);
            _registratrionCourseService.RegisterCourse(studentId);

            nameStudent = "Emilse";
            age = 19;
            studentId = _studentService.RegisterStudent(nameStudent, age);
            nameCourse = "Redes";
            courseCost = 20;
            startDateCourse = DateTime.Now;
            endDateCourse = DateTime.Now.AddMonths(3);
            courseId = _courseService.RegisterCourse(nameCourse, courseCost, startDateCourse, endDateCourse);

            pay = 20;

            _paymentCourseService.RegisterPaymentCourse(studentId, courseId, pay);
            _registratrionCourseService.RegisterCourse(studentId);

            var studentCourses = _registratrionCourseService.GetAllRegisterCourses();
            Assert.NotNull(studentCourses);
            Assert.NotEmpty(studentCourses);
        }

        [Fact]
        public void GetRegistrationCoursebyId()
        {
            string nameStudent = "Daniela";
            int age = 20;
            var studentId = _studentService.RegisterStudent(nameStudent, age);
            string nameCourse = "Informatica";
            int courseCost = 10;
            DateTime startDateCourse = DateTime.Now;
            DateTime endDateCourse = DateTime.Now.AddMonths(3);
            var courseId = _courseService.RegisterCourse(nameCourse, courseCost, startDateCourse, endDateCourse);

            int pay = 10;
            var paymentCourseId = _paymentCourseService.RegisterPaymentCourse(studentId, courseId, pay);
            var registrationCourseId = _registratrionCourseService.RegisterCourse(studentId);
            var registrationCourse = _registratrionCourseService.GetByIdRegisterCourse(registrationCourseId);
            Assert.Equal(registrationCourseId, registrationCourse.Id);
        }

        [Fact]
        public void RemoveRegistrationCourse()
        {
            string nameStudent = "Daniela";
            int age = 20;
            var studentId = _studentService.RegisterStudent(nameStudent, age);
            string nameCourse = "Informatica";
            int courseCost = 10;
            DateTime startDateCourse = DateTime.Now;
            DateTime endDateCourse = DateTime.Now.AddMonths(3);
            var courseId = _courseService.RegisterCourse(nameCourse, courseCost, startDateCourse, endDateCourse);

            int pay = 10;
            var paymentCourseId = _paymentCourseService.RegisterPaymentCourse(studentId, courseId, pay);
            var registrationCourseId = _registratrionCourseService.RegisterCourse(studentId);
            var registrationCourse = _registratrionCourseService.GetByIdRegisterCourse(registrationCourseId);
            _registratrionCourseService.RemoveRegisterCourse(registrationCourse);
            var registerCourses = _registratrionCourseService.GetAllRegisterCourses();
            var newRegistrationCourse = registerCourses.FirstOrDefault(s => s.Id == registrationCourseId);
            Assert.Null(newRegistrationCourse);
        }

        #endregion
    }
}
