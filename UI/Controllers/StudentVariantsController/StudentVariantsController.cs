using Microsoft.AspNetCore.Mvc;
using Infrastructure;

namespace UI.Controllers.StudentVariantsController
{
    public class StudentVariantsController : Controller
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public StudentVariantsController(IApplicationDbContext applicationDbContext)
            => _applicationDbContext = applicationDbContext;


        [HttpGet]
        public IActionResult StudentVariantsCreate()
        {
            if (_applicationDbContext.DataBase == null)
                return Redirect("~/Db/ShowAllDataBases");
            _applicationDbContext.GenerateTable();
            var generatedTable = _applicationDbContext.DataBase.StudentVariants.GetAll();
            return View(generatedTable);
        }

    }
}
