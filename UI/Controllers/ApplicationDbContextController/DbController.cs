using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.ApplicationDbContextController
{
    
    public class DbController : Controller
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public DbController(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        [HttpGet]
        public IActionResult ShowAllDataBases()
        {
            var _dbList = _applicationDbContext.ShowAllDataBases();
            return View(_dbList);
        }
        [HttpGet]
        public IActionResult ShowCurrentDataBase()
        {
            var _currDb = _applicationDbContext.ShowCurrentDataBase();
            if (_currDb == string.Empty)
                return View("ShowCurrentDataBase", "Еще не открыта ни одна бд");
            return View("ShowCurrentDataBase",_currDb);
        }



        [HttpGet]
        public IActionResult CreateDataBase()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateDataBase(string name)
        {
            _applicationDbContext
                .CreateDataBase(name);
            return Redirect("~/Db/ShowAllDataBases");
        }

        
        [HttpGet]
        public IActionResult DeleteDataBase()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteDataBase(string name)
        {
            _applicationDbContext.DeleteDataBase(name);
            return Redirect("~/Db/ShowAllDataBases");
        }


        [HttpGet]
        public IActionResult SwitchDataBase()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SwitchDataBase(string name)
        {
            _applicationDbContext.SwitchDataBase(name);
            return Redirect("~/Db/ShowAllDataBases");
        }


        [HttpGet]
        public IActionResult OpenDataBase()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OpenDataBase(string name)
        {
            _applicationDbContext.OpenDataBase(name);
            return Redirect("~/Db/ShowAllDataBases");
        }

        public IActionResult Students()
        {
            if (_applicationDbContext.DataBase == null)
                return Redirect("~/Db/ShowAllDataBases");
            return Redirect("~/Students/ShowAllStudents");
        }
        public IActionResult Variants()
        {
            if (_applicationDbContext.DataBase == null)
                return Redirect("~/Db/ShowAllDataBases");
            return Redirect("~/Variants/ShowAllVariants");
        }
        public IActionResult StudentsVariants()
        {
            if (_applicationDbContext.DataBase == null)
                return Redirect("~/Db/ShowAllDataBases");
            return Redirect("~/StudentVariants/StudentVariantsCreate");
        }
        public IActionResult StudentsVariantsMarks()
        {
            return Redirect("~/StudentsVariantsMarks/ShowAllStudentsVariantMarks");
        }
    }
}
