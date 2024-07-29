using BLL.LogicServices;
using BOL.DatabaseEntities;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsLogic _studentsLogic;

        public StudentsController(IStudentsLogic studentsLogic)
        {
            _studentsLogic = studentsLogic;
        }

        public IActionResult StudentsList()
        {
            // get students list
            List<Students> result = new List<Students>();

            result = _studentsLogic.GetStudentsListLogic().ToList();

            return View(result);
        }
    }
}
