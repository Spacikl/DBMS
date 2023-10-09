using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace UI.Controllers.VariantController
{
    public class VariantsController : Controller
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public VariantsController(IApplicationDbContext applicationDbContext)
            => _applicationDbContext = applicationDbContext;

        
        [HttpGet]
        public IActionResult ShowAllVariants()
        {
            if (_applicationDbContext.DataBase == null)
                return Redirect("~/Db/ShowAllDataBases");
            var variants = _applicationDbContext.DataBase.Variants.GetAll();
            return View(variants);
        }

        
        [HttpGet]
        public IActionResult CreateVariant()
            => View();

        [HttpPost]
        public IActionResult CreateVariant(string pathToFile)
        {
            _applicationDbContext.DataBase.Variants.Add(pathToFile);
            return Redirect("~/Variants/ShowAllVariants");
        }


        [HttpGet]
        public IActionResult DeleteVariantById()
            => View();
        [HttpPost]
        public IActionResult DeleteVariantById(int id)
        {
            _applicationDbContext.DataBase.Variants.DeleteById(id, new CancellationToken());
            return Redirect("~/Variants/ShowAllVariants");
        }


        [HttpGet]
        public IActionResult UpdateVariantById()
            => View();
        [HttpPost]
        public IActionResult UpdateVariantByid(int id, string pathToFile)
        {
            _applicationDbContext.DataBase.Variants.UpdateById(id, pathToFile, new CancellationToken());
            return Redirect("~/Variants/ShowAllVariants");
        }
    }
}
