using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace UI.Controllers.StudentController
{
    public class StudentsController : Controller
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public StudentsController(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent(string name, string surname, string patronymic)
        {
            _applicationDbContext.DataBase.Students.Add(name + " " + surname + " " + patronymic);
            return Redirect("~/Students/ShowAllStudents");
        }

        [HttpGet]
        public IActionResult ShowAllStudents()
        {
            if (_applicationDbContext.DataBase == null)
                return Redirect("~/Db/ShowAllDataBases");
            var students = _applicationDbContext.DataBase.Students.GetAll(); 
            return View(students);
        }
        [HttpGet]
        public IActionResult DeleteStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteStudent(string id)
        {
            var studentData = _applicationDbContext.DataBase.Students.FindById(id).Split(' ');

            if (studentData[0] == "Не")
                return Redirect("~/Students/ShowAllStudents");

            var student = studentData[1] + " " + studentData[2] + " " + studentData[3];
            
            //удаляем из таблицы студенты
            _applicationDbContext.DataBase.Students.DeleteById(studentData[0], new CancellationToken());
            //удаляем из таблицы студенты-варианты
            _applicationDbContext.DataBase.StudentVariants.DeleteById(studentData[0], new CancellationToken());
            //удаляем из таблицы студенты-варианты-оценки
            _applicationDbContext.DataBase.StudentVariantMarks.DeleteStudent(student);
            return Redirect("~/Students/ShowAllStudents");
        }

        [HttpGet]
        public IActionResult UpdateStudentById()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateStudentById(string id, string name, string surname, string patronymic)
        {
            var updatedStudent = name + " " + surname + " " + patronymic;

            var notUpdatedStudent = _applicationDbContext.DataBase.Students.FindById(id);
            if (notUpdatedStudent == "Не найдено: (")
            {
                Console.WriteLine("Такого студента нет");
                return Redirect("~/Students/ShowAllStudents");
            }

            _applicationDbContext.DataBase.Students
                .UpdateById(id, updatedStudent, new CancellationToken());

            _applicationDbContext.DataBase.StudentVariantMarks
                .UpdateStudent(notUpdatedStudent, updatedStudent);

            return Redirect("~/Students/ShowAllStudents");
        }

        [HttpGet]
        public IActionResult GetStudentById()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetStudentById(string id)
        {
            var foundStudent = _applicationDbContext.DataBase.Students.FindById(id);
            return View("ShowCurrentStudent", foundStudent);
        }


    }
}
