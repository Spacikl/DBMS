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
        public IActionResult DeleteVariantById(string id)
        {
            //удаляем варианты в таблице Вариантов
            
            _applicationDbContext.DataBase
                .Variants.DeleteById(id, new CancellationToken());
            
            //найти всех студентов из таблицы Студенты - Варианты, и удалить там строчки
            
            var studentsId = _applicationDbContext.DataBase
                .StudentVariants.FindStudentsByVariantId(id);
            
            if (studentsId.Count() == 0)
                return Redirect("~/Variants/ShowAllVariants");
            
            foreach (var _id in studentsId)
            {
                var student = _applicationDbContext.DataBase.Students
                    .FindById(_id).Split(' ').ToList();
                if (student[0] != "Не")
                {
                    _applicationDbContext.DataBase
                        .StudentVariantMarks.DeleteStudentsVariant(student[1], student[2], student[3]);
                }
            }
            return Redirect("~/Variants/ShowAllVariants");
        }


        [HttpGet]
        public IActionResult UpdateVariantById()
            => View();
        [HttpPost]
        public IActionResult UpdateVariantByid(string id, string pathToFile)
        {
            _applicationDbContext.DataBase.Variants.UpdateById(id, pathToFile, new CancellationToken());
            return Redirect("~/Variants/ShowAllVariants");
        }
    }
}
