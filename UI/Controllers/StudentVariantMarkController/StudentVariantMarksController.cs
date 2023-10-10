using Infrastructure;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace UI.Controllers.StudentVariantMarkController
{
    public class StudentVariantMarksController : Controller
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public StudentVariantMarksController(IApplicationDbContext applicationDbContext)
            => _applicationDbContext = applicationDbContext;


        [HttpGet]
        public IActionResult ShowFullTable()
        {
            if (_applicationDbContext.DataBase == null)
                return Redirect("~/Db/ShowAllDataBases");
            
            var fullTable = _applicationDbContext
                .DataBase
                .StudentVariantMarks.GetAll();

            return View(fullTable);
        }

        [HttpGet]
        public IActionResult AddMark()
        {
            if (_applicationDbContext.DataBase == null)
                return Redirect("~/Db/ShowAllDataBases");
            return View("AddMark");
        }
        [HttpPost]
        public IActionResult AddMark(string student, string mark)
        {
            _applicationDbContext.DataBase.StudentVariantMarks.AddMark(student, mark);
            return Redirect("~/StudentVariantMarks/ShowFullTable");
        }

    }
}
