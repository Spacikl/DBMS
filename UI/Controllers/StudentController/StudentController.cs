using Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.StudentController
{
    public class StudentController
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public StudentController(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        [HttpPost]
        public void CreateStudent(string student)
        {
            _applicationDbContext.DataBase.Students.Add(student);
        }

    }
}
