using Infrastructure;
using Microsoft.AspNetCore.Mvc;

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
            _applicationDbContext.DataBase.Students.DeleteById(int.Parse(id), new CancellationToken());
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
            _applicationDbContext.DataBase.Students.UpdateById(int.Parse(id), name + " " + surname + " " + patronymic, new CancellationToken());
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
            var foundStudent = _applicationDbContext.DataBase.Students.FindById(int.Parse(id));
            return View("ShowCurrentStudent", foundStudent);
        }


    }
}
