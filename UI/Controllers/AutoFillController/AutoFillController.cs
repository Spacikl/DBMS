using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace UI.Controllers.AutoFillController
{
    public class AutoFillController : Controller
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public AutoFillController(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult AutoComplete()
        {
            if (_applicationDbContext.DataBase == null)
                return Redirect("~/Db/ShowAllDataBases");
            return View();
        }

        [HttpPost]
        public IActionResult AutoComplete(string path_to_name, string path_to_var)
        {
            _applicationDbContext.AutoFill(path_to_name, path_to_var);
            return Redirect("~/Db/ShowAllDataBases");
        }

    }
}
